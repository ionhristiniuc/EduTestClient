using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Repositories;

namespace ClientLibraryTest
{
    class Program
    {
        private static ICoursesRepository _coursesRepository;
        private static IUsersRepository _usersRepository;

        static void Main(string[] args)
        {
            var authenticationService = new AuthenticationService(
                "http://192.168.56.22/app_dev.php",
                "token",
                "1_random_id",
                "secret"
                );

            if (!authenticationService.Authenticate("test", "test"))
                Console.WriteLine("Failed to authenticate!");

            _coursesRepository = new CoursesRepository("http://192.168.56.22/app_dev.php", 
                "courses", authenticationService);


            int courseId = AddCourse();
            EditCourse(courseId);            
            PrintCourses();
            RemoveCourse(courseId);
        }        

        private static void PrintCourses()
        {
            var courses = _coursesRepository.GetList();

            foreach (var course in courses.data)
            {
                Console.WriteLine("Course id: {0}, name: {1}", course.id, course.name);
                foreach (var module in course.modules)
                {
                    Console.WriteLine("\tModule id: {0}, name: {1}", module.id, module.name);

                    foreach (var chapter in module.chapters)
                    {
                        Console.WriteLine("\t\tChapter id: {0}, name: {1}", chapter.id, chapter.name);
                    }
                }
            }
        }

        private static int AddCourse()
        {
            var course = new Course()
            {
                name = "MyCourse"
            };

            try
            {                
                return _coursesRepository.Add(course);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred while adding course: {0}", e);
                throw;
            }            
        }

        private static void EditCourse(int courseId)
        {
            try
            {
                var course = _coursesRepository.Get(courseId);               
                course.name = "Edited course";
                _coursesRepository.Update(course, courseId);                
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred while editing course: {0}", e);
            }            
        }

        private static void RemoveCourse(int courseId)
        {
            try
            {
                _coursesRepository.Remove(courseId);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred while editing course: {0}", e);
            }
        }
    }
}
