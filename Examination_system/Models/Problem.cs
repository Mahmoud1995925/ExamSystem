using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Problem
    {
        [Key]
        public int Problem_id { get; set; }
        [Required]
        public string Problem_Desc { get; set; }
       
        public string User_id { get; set; }
        public virtual ApplicationUser Student { get; set; }

    }
}