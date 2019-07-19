using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_system.Models
{
    public class Question_Asnwer
    {
        [Key, Column(Order = 0)]
        public int Question_id { set; get; }

        [Key, Column(Order = 1)]
        public int Answer_id { set; get; }
        public virtual Question Question { get; set; }
        public virtual Answer answer { get; set; }

    }
}