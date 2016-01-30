using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Repositories;
using TeacherEduTest.SideMenu.AddNewModelsWindows;
using TeacherEduTest.UIModels;

namespace TeacherEduTest.SideMenu
{
    /// <summary>
    /// Interaction logic for SideMenuPanel.xaml
    /// </summary>
    public partial class SideMenuPanel : UserControl
    {
        private readonly IAuthenticationService _accountService;
        
        private readonly Grid _contentMenuGrid;
        private ObservableCollection<ObservableModuleModel> moduleList;
        private IModulesRepository _modulesService;
        private IChaptersRepository _chaptersService;
        private ITopicsRepository _topicsService;

        private SideMenuPanel()
        {
            InitializeComponent();
        }

        public SideMenuPanel(IAuthenticationService accountService, Grid contentMenuGrid)
            : this()
        {
            _accountService = accountService;
            _contentMenuGrid = contentMenuGrid;
            InitCourses();
            InitServices();
        }

        private void InitServices()
        {
            _modulesService = new ModulesRepository(AppConfig.ServiceUrl, _accountService);
            _chaptersService = new ChaptersRepository(AppConfig.ServiceUrl, _accountService);
            _topicsService = new TopicsRepository(AppConfig.ServiceUrl, _accountService);
        }

        private void InitCourses()
        {
            ICoursesRepository coursesService = new CoursesRepository(AppConfig.ServiceUrl, _accountService);

            var courses = coursesService.GetList();

            CoursesComboBox.ItemsSource = courses.data;
            CoursesComboBox.DisplayMemberPath = "name";
            CoursesComboBox.SelectedValuePath = "id";
        }

        private void CoursesTreeView_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private  void CoursesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICoursesRepository coursesService =
               new CoursesRepository(AppConfig.ServiceUrl, _accountService);

            Course selectedCourse = coursesService.Get((int)CoursesComboBox.SelectedValue);

            WindowCreator.GetCurseMenuPanel(_accountService, selectedCourse);
            InitCourseTreeView(selectedCourse);
        }

        private void InitCourseTreeView(Course currentCourseModel)
        {
            moduleList = new ObservableCollection<ObservableModuleModel>(ConvertToObservable(currentCourseModel.modules));
            CoursesTreeView.DataContext = moduleList;
        }

        private void CoursesTreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //MessageBox.Show(CoursesTreeView.SelectedItem.GetType().ToString());
        }

        private void ModuleMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableModuleModel selectedModuleModel = (ObservableModuleModel)CoursesTreeView.SelectedItem;
            MenuItem menuItem = (MenuItem)sender;

            if (menuItem.Name.Equals("ModuleRemoveMenuItem"))
            {
                if (isRemovable(selectedModuleModel.Chapters.Count))
                {
                    if (_modulesService.Remove(selectedModuleModel.Id))
                        moduleList.Remove(selectedModuleModel);
                    else
                        MessageBox.Show("Remove Module error occured",
                            "Error",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
            }
            else if (menuItem.Name.Equals("AddChapterMenuItem"))
            {
                var addChapterWindow = new AddNewChapterWindow();
                addChapterWindow.ShowDialog();


                var newChId = _chaptersService.Add(new Chapter()
                {
                    name = addChapterWindow.AddedChapterName,
                    module = selectedModuleModel.Id
                });

                if (newChId.HasValue)
                {
                    selectedModuleModel.Chapters.Add(new ObservableChapterModel()
                    {
                        Name = addChapterWindow.AddedChapterName,
                        Topics = new ObservableCollection<ObservableTopicModel>(),
                    });
                }
                else
                {
                    MessageBox.Show("Add Chapter error occured", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ChepterItem_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableChapterModel selectedChapterModel = (ObservableChapterModel)CoursesTreeView.SelectedItem;
            MenuItem menuItem = (MenuItem)sender;

            if (menuItem.Name.Equals("ChapterRemoveMenuItem"))
            {
                foreach (var module in moduleList)
                {
                    if (module.Id == selectedChapterModel.ModuleId)
                        if (isRemovable(selectedChapterModel.Topics.Count))
                        {
                            if (_chaptersService.Remove(selectedChapterModel.Id))
                                module.Chapters.Remove(selectedChapterModel);
                            else
                                MessageBox.Show("Remove Chapter error occured", "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                }
            }
            else if (menuItem.Name.Equals("AddTopicMenuItem"))
            {
                // no_implementation _topicsService.AddTopic()
                var addTopicWindow = new AddNewTopicWindow();
                addTopicWindow.ShowDialog();

                selectedChapterModel.Topics.Add(new ObservableTopicModel()
                {
                    Name = addTopicWindow.AddedTopicName,
                    ChapterId = selectedChapterModel.Id
                });
            }
        }

        private void TopicMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            ObservableTopicModel selectedTopicModel = (ObservableTopicModel)CoursesTreeView.SelectedItem;

            foreach (var model in moduleList)
            {
                foreach (var chapter in model.Chapters)
                {
                    chapter.Topics.Remove(selectedTopicModel);
                }
            }
        }

        private ObservableCollection<ObservableModuleModel> ConvertToObservable(IEnumerable<Module> model)
        {
            return new ObservableCollection<ObservableModuleModel>(model.Select(m => new ObservableModuleModel()
            {
                Name = m.name,
                Id = m.id,
                Chapters = new ObservableCollection<ObservableChapterModel>(m.chapters.Select(c => new ObservableChapterModel()
                {
                    Name = c.name,
                    Id = c.id,
                    ModuleId = m.id,
                    Topics = new ObservableCollection<ObservableTopicModel>(c.topics.Select(t => new ObservableTopicModel()
                    {
                        Name = t.name,
                        Id = t.id,
                        ChapterId = c.id
                    }))
                }))
            }));
        }
  
        private bool isRemovable( int size )
        {
            if (size != 0)
            {
                MessageBox.Show("Remove error occured, the element must be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

    }
}