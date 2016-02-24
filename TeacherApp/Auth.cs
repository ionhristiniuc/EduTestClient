using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherApp
{
    public static class Auth
    {
        public const string ServiceUrl = "http://192.168.56.22/app_dev.php";
        public const string AuthPath = "token";
        public const string ClientId = "1_random_id";
        public const string ClientSecret = "secret";
    }
}