using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class TopicsRepository : GenericRepository<Topic>, ITopicsRepository
    {
        public TopicsRepository(string serviceUrl, string basePath, IAuthenticationService authenticator) 
            : base(serviceUrl, basePath, authenticator)
        {
        }
    }
}