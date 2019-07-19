using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class ExamCourse
    {
        [Key, Column(Order = 0)]
        public int Exam_id { set; get; }

        [Key, Column(Order = 1)]
        public int Course_id { set; get; }
        public virtual Exam exam { get; set; }
        public virtual Course course { get; set; }
    }
}