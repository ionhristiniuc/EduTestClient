using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class Course
    {
        [Ignore]
        public int id { get; set; }
        public string name { get; set; }
        [Ignore]
        public List<Module> modules { get; set; }
    }
}
