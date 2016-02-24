using EduTestServiceClient.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using TeacherApp.App_Start;
using TeacherApp.Security;

namespace TeacherApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        var currentUser = HttpContext.Current.User as CustomPrincipal;

                        if (currentUser == null)
                            throw new Exception("No credentials");

                        var authData = currentUser.AuthData;

                        if (authData == null)
                            throw new Exception("No credentials");

                        // should call service to get user object base on username
                        // also should store token object                                                                                                     
                        //IUserAccountService accountService = new UserAccountService(new UserRepository());
                        string login = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

                        IUsersRepository usersRepository = new UsersRepository(Auth.ServiceUrl, authData.access_token);
                        var users = usersRepository.GetList();
                        var user = users.data.FirstOrDefault();

                        if (user == null)
                            throw new Exception("User not found");

                        currentUser.User = user;

                        //HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(username, "Forms"), roles.Split(';'));
//                        HttpContext.Current.User = new CustomPrincipal(userModel);
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
