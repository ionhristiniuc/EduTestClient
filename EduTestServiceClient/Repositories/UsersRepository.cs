using EduTestServiceClient.DTO;
using RestSharp;

namespace EduTestServiceClient.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(string serviceUrl, IAuthenticationService authenticator)
            : base(serviceUrl, "users", authenticator)
        {

        }

        public void AddCourseToUser(int userId, int courseId)
        {
            var request = new RestRequest($"{BasePath}/{userId}/courses");
            request.AddParameter("course", courseId);
            var response = Client.Execute(request);

            if (response.ErrorException != null)
                throw response.ErrorException;
        }
    }
}