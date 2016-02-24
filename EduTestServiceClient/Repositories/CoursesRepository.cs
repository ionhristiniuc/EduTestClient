using EduTestServiceClient.DTO;
using RestSharp;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class CoursesRepository : GenericRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(string serviceUrl, string accessToken)
            : base(serviceUrl, "courses", accessToken)
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