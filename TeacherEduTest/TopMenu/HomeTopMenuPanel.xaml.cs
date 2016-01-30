using System.Windows;
using System.Windows.Controls;
using EduTestServiceClient.Repositories;
using TeacherEduTest.ContentMenu;

namespace TeacherEduTest.TopMenu
{
    /// <summary>
    /// Interaction logic for TopMenuPanel.xaml
    /// </summary>
    public partial class HomeTopMenuPanel : UserControl
    {
        private readonly IAuthenticationService _accountService;     

        private HomeTopMenuPanel()
        {
            InitializeComponent();
        }

        public HomeTopMenuPanel(IAuthenticationService accountService)
            :this()
        {
            _accountService = accountService;          
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCreator.GetMainMenuPanel(_accountService);
        }
    }
}
