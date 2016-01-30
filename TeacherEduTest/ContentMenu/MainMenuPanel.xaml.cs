using System.Windows.Controls;
using EduTestServiceClient.Repositories;

namespace TeacherEduTest.ContentMenu
{
    /// <summary>
    /// Interaction logic for ContentMenuPanel.xaml
    /// </summary>
    public partial class MainMenuPanel : UserControl
    {
        private readonly IAuthenticationService _accountService;

        private MainMenuPanel()
        {
            InitializeComponent();
        }

        public MainMenuPanel(IAuthenticationService accountService)
            :this()
        {
            _accountService = accountService;
        }
    }
}
