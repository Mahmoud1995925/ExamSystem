using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Student_course
    {
        [Key, Column(Order = 0)]
        public int Course_id { set; get; }

        [Key, Column(Order = 1)]
        public string UserId { set; get; }

        public virtual Course Course { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}