using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class Module
    {
        [Ignore]
        public int id { get; set; }
        public string name { get; set; }
        public int course { get; set; }
        [Ignore]
        public List<Chapter> chapters { get; set; }
    }
}
