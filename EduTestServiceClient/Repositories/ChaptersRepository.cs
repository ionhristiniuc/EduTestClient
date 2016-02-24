using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class ChaptersRepository : GenericRepository<Chapter>, IChaptersRepository
    {
        public ChaptersRepository(string serviceUrl, string accessToken) 
            : base(serviceUrl, "chapters", accessToken)
        {
        }
    }
}