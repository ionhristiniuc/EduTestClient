using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public interface IAuthenticationService
    {
        string ServiceUrl { get; }
        string AuthPath { get; }
        AuthenticationResponse AuthResponse { get; }
        bool Authenticate(string username, string password);
    }
}
