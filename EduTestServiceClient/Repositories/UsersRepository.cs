using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(string serviceUrl, string basePath, IAuthenticationService authenticator)
            : base(serviceUrl, basePath, authenticator)
        {

        }
    }
}