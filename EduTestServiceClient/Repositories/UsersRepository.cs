using EduTestServiceClient.DTO;
using RestSharp;

namespace EduTestServiceClient.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(string serviceUrl, string accessToken)
            : base(serviceUrl, "users", accessToken)
        {

        }        
    }
}