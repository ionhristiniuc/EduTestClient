using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class ModulesRepository : GenericRepository<Module>, IGenericRepository<Module>
    {
        public ModulesRepository(string serviceUrl, string basePath, IAuthenticationService authenticator)
            : base(serviceUrl, basePath, authenticator)
        {
        }
    }
}