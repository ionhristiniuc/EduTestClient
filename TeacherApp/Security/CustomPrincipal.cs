using EduTestServiceClient.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TeacherApp.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public User User { get; set; }
        public IIdentity Identity { get; private set; }
        public AuthenticationResponse AuthData { get; set; }

        public CustomPrincipal(User user, AuthenticationResponse resp)
        {
            this.User = user;

            if (User != null)
                Identity = new GenericIdentity(user.username);
        }        

        public bool IsInRole(string role)
        {
            return User.roles.Contains(role);
        }        
    }
}