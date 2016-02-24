using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduTestServiceClient.DTO;

namespace TeacherApp.Models
{
    public class CourseModel
    {
        public string Name { get; set; }

        public CourseModel(Course course)
        {
            Name = course.name;
        }

        public CourseModel()
        {            
        }        

        public Course ToContract()
        {
            return new Course()
            {
                name = Name
            };
        }
    }
}