using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Repositories;

namespace TeacherEduTest.Authentication
{
    /// <summary>
    ///     Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        private static readonly object AuthenticationMonitor = new object();
        private static bool _isAuthenticationBegun;
        public AuthenticationWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }

        private void SignInButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isAuthenticationBegun)
                return;

            _isAuthenticationBegun = true;

            string username = "test";
            string password = "test";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return;
            try
            {                
                var authService = new AuthenticationService(
                AppConfig.ServiceUrl,
                AppConfig.AuthPath,
                AppConfig.ClientId,
                AppConfig.Secret
                );

                if (authService.Authenticate(username, password))
                {
                    /*IQuestionsRepository questionsService = new QuestionsRepository(authenticationService.AuthResponse.access_token, new JsonSerializer());
                    var question = new VariantQuestionModel()
                    {
                        Content = "Choose an answer!",
                        Enabled = true,
                        TopicId = 1,
                        Type = QuestionType.choice,
                        UserId = 1,
                        Variants = new List<VariantModel>
                        {
                            new VariantModel() { Body = "Answer A", Correct = false},
                            new VariantModel() { Body = "Answer B", Correct = false},
                            new VariantModel() { Body = "Answer C", Correct = true},
                         }
                    };
                    var result = await questionsService.AddQuestion(question.TopicId, question);
                    MessageBox.Show(result.ToString());*/

                    IUsersRepository usersService = new UsersRepository(AppConfig.ServiceUrl, authService);

                    // TODO should find a method to get logged in user id
                    //User user = usersService.Get();

                    //if (!user.Roles.Any(
                    //        r => r.Equals(RoleType.Teacher.ToString())
                    //            || r.Equals(RoleType.Admin.ToString())))
                        //return;

                    lock (AuthenticationMonitor)
                    {
                        var mainWindow = new MainWindow(authService);
                        Close();
                        mainWindow.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email address or Password are incorrect.");
                MessageBox.Show(ex.ToString());
            }

            _isAuthenticationBegun = false;
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2) - 100;
        }
    }
}