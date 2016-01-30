using System.Windows;
using System.Windows.Controls;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Repositories;
using TeacherEduTest.ContentMenu;

namespace TeacherEduTest.TopMenu
{
    /// <summary>
    /// Interaction logic for TopMenuPanel.xaml
    /// </summary>
    public partial class CourseTopMenuPanel : UserControl
    {
        private readonly IAuthenticationService _accountService;
        private readonly Course _courseModel;

        private CourseTopMenuPanel()
        {
            InitializeComponent();
        }

        public CourseTopMenuPanel(IAuthenticationService accountService, Course courseModel)
            :this()
        {
            _accountService = accountService;
            _courseModel = courseModel;
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCreator.GetMainMenuPanel(_accountService);
        }
    }
}
