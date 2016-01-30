using EduTestServiceClient.DTO;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class CoursesRepository : GenericRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(string serviceUrl, IAuthenticationService authenticator)
            : base(serviceUrl, "courses", authenticator)
        {
        }
    }
}