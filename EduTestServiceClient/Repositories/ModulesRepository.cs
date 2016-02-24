using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class ModulesRepository : GenericRepository<Module>, IModulesRepository
    {
        public ModulesRepository(string serviceUrl, string accessToken)
            : base(serviceUrl, "modules", accessToken)
        {
        }
    }
}