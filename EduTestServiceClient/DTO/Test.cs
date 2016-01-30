using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class Test
    {
        [Ignore]
        public int id { get; set; }
        public Environment type { get; set; }
        public int duration { get; set; }
    }
}
