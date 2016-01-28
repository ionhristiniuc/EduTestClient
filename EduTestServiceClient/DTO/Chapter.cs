using System.Collections.Generic;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class Chapter
    {
        [Ignore]
        public int id { get; set; }
        public string name { get; set; }
        public int module { get; set; }
        [Ignore]
        public List<Topic> topics { get; set; }
    }
}