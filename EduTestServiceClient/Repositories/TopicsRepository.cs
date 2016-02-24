using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class TopicsRepository : GenericRepository<Topic>, ITopicsRepository
    {
        public TopicsRepository(string serviceUrl, string accessToken) 
            : base(serviceUrl, "topics", accessToken)
        {
        }
    }
}