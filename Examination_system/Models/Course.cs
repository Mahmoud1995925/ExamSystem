using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Course
    {
        [Key]
        public int Course_id { get; set; }

        [Display(Name = "Course Name")]
        [MaxLength(20)]
        public string Course_Name { get; set; }

        [Display(Name = "Course Description")]
        [MaxLength(60)]
        public string Course_Desc { get; set; }

        [Display(Name = "More Info")]
        public string Info { get; set; }

        public virtual ICollection<ExamCourse> ExamCourses { get; set; }
        public virtual ICollection<Student_course> Student_Courses { get; set; }

    }
}