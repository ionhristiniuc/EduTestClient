using System.Collections.Generic;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class User
    {
        [Ignore]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Ignore]
        public List<string> roles { get; set; }
        [Ignore]
        public List<Course> courses { get; set; }
    }
}