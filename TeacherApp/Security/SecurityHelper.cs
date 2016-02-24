using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using EduTestServiceClient.DTO;

namespace TeacherApp.Security
{
    public static class SecurityHelper
    {
        public static string GetAccessToken(IPrincipal user)
        {
            var custUser = user as CustomPrincipal;
            return custUser?.AuthData?.access_token;
        }

        public static User GetCurrentUser(IPrincipal user)
        {
            var custUser = user as CustomPrincipal;
            return custUser?.User;
        }
    }
}