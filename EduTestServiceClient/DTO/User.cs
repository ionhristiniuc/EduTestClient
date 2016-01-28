using System.Collections.Generic;

namespace EduTestServiceClient.DTO
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> roles { get; set; }
        public List<Course> courses { get; set; }
    }
}