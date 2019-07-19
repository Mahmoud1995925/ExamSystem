using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class validateAnswers
    {
        public int question_id { get; set; }
        public int user_answer_id { get; set; }
        public int correct_answer_id { get; set; }
        
        public Question question { get; set; }
        public Answer usr_ans {get; set; }
        public Answer Correct_ans { get; set; }

    }
}