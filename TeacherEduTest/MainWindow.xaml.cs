using System.Windows;
using EduTestServiceClient.Repositories;
using TeacherEduTest.ContentMenu;
using TeacherEduTest.SideMenu;
using TeacherEduTest.TopMenu;

namespace TeacherEduTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SideMenuPanel _sideMenuPanel;
        private HomeTopMenuPanel _homeTopMenuPanel;
        private readonly IAuthenticationService _accountService;

        private MainWindow()
        {
            InitializeComponent();             
        }

        public MainWindow(IAuthenticationService accountService)
            :this()
        {
            this._accountService = accountService;
            WindowCreator.ContentGrid = ContentMenuGrid;
            WindowCreator.TopMenuGrid = TopMenuGrid;

            InitSideMenuPanel();
         //   InitTopMenuPanel();
            InitMainMenuPanel();
        }

        private void InitTopMenuPanel()
        {
           _homeTopMenuPanel = new HomeTopMenuPanel(_accountService);
            this.TopMenuGrid.Children.Add(_homeTopMenuPanel);
        }

        private void InitSideMenuPanel()
        {
            _sideMenuPanel = new SideMenuPanel(_accountService, this.ContentMenuGrid);
            this.SideMenuGrid.Children.Add(_sideMenuPanel);
        }

        private void InitMainMenuPanel()
        {
            WindowCreator.GetMainMenuPanel(_accountService);          
        }
    }
}
