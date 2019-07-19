using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examination_system.Models
{
    public class Question
    {
        [Key]
        public int Question_id { get; set; }

        public string Question_desc { get; set; }

        public int Correct_Answer_id { get; set; }

        public Nullable<int> Question_Grade { get; set; }

        public virtual ICollection<Exam_Question>Examquestion { get; set; }
        public virtual ICollection<Question_Asnwer> Question_Asnwers { get; set; }


    }
}