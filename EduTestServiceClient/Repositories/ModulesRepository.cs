using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class ModulesRepository : GenericRepository<Module>, IModulesRepository
    {
        public ModulesRepository(string serviceUrl, IAuthenticationService authenticator)
            : base(serviceUrl, "modules", authenticator)
        {
        }
    }
}