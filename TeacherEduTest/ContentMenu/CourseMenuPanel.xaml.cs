using System.Windows.Controls;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Repositories;

namespace TeacherEduTest.ContentMenu
{
    /// <summary>
    /// Interaction logic for CourseMenuPanel.xaml
    /// </summary>
    public partial class CourseMenuPanel : UserControl
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Course _courseModel;

        private CourseMenuPanel()
        {
            InitializeComponent();
        }

        public CourseMenuPanel(IAuthenticationService accountService, Course courseModel)
            :this()
        {
            _authenticationService = accountService;            
            _courseModel = courseModel;
        }
    }
}
