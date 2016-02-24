using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public interface ICoursesRepository : IGenericRepository<Course>
    {
        void AddCourseToUser(int userId, int courseId);
    }
}