using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class CoursesRepository : GenericRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(string serviceUrl, string basePath, IAuthenticationService authenticator)
            : base(serviceUrl, basePath, authenticator)
        {
        }
    }
}