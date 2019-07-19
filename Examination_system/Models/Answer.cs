using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_system.Models
{
    public class Answer
    {
        [Key]
        public int Answer_id { get; set; }

        public string Answer_desc { get; set; }
       public virtual ICollection<Question_Asnwer> Question_Asnwers { get; set; }
    }
}