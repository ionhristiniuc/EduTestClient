using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.Utils;

namespace EduTestServiceClient.DTO
{
    public class Question
    {
        [Ignore]
        public int Id { get; set; }
        public string content { get; set; }
        public bool enabled { get; set; }
        public int topic { get; set; }
        public QuestionType type { get; set; }
        public int text_limit { get; set; }
        public int correct_choices { get; set; }
    }
}
