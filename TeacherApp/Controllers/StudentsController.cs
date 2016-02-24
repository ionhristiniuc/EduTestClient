using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduTestServiceClient.Repositories;

namespace TeacherApp.Controllers
{
    public class StudentsController : Controller
    {
        private IUsersRepository _usersRepository;

        public StudentsController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            var students = _usersRepository.GetList();
            
            return View(students);
        }        
    }
}