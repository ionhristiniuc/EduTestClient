using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class TopicsRepository : GenericRepository<Topic>, ITopicsRepository
    {
        public TopicsRepository(string serviceUrl, IAuthenticationService authenticator) 
            : base(serviceUrl, "topics", authenticator)
        {
        }
    }
}