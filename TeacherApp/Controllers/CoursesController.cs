using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduTestServiceClient.Repositories;
using TeacherApp.Models;
using TeacherApp.Security;

namespace TeacherApp.Controllers
{
    public class CoursesController : Controller
    {                    
        // GET: Courses
        public ActionResult Index()
        {
            var token = SecurityHelper.GetAccessToken(User);
            ICoursesRepository coursesRepository = new CoursesRepository(Auth.ServiceUrl, token);
            var courses = coursesRepository.GetList();
            if (courses?.data != null)
            {
                var coursesModel = courses.data.Select(c => new CourseModel(c)).ToList();
                return View(coursesModel);
            }
            else
                return View(new List<CourseModel>());

        }

        [HttpGet]
        public ActionResult AddCourse()
        {            
            var course = new CourseModel();
            return View(course);
        }

        [HttpPost]
        public ActionResult AddCourse(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                var token = SecurityHelper.GetAccessToken(User);
                ICoursesRepository coursesRepository = new CoursesRepository(Auth.ServiceUrl, token);

                var courseId = coursesRepository.Add(course.ToContract());

                if (!courseId.HasValue)
                {
                    return new HttpStatusCodeResult(
                        HttpStatusCode.InternalServerError);
                }
                else
                {
                    var masterUser = HttpContext.User.Identity;
                    //var user = SecurityHelper.GetCurrentUser();
                    //coursesRepository.AddCourseToUser(user.id, courseId.Value);

                    return RedirectToAction("Index");
                }                                                           
            }

            return View(course);
        }
    }
}