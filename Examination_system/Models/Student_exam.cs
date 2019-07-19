using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Student_exam
    {
        [Key, Column(Order = 0)]
        public int Exam_id { set; get; }

        [Key, Column(Order = 1)]
        public String UserId { set; get; }
        public Nullable<int> Grade { set; get; }
        public virtual Exam exam { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}