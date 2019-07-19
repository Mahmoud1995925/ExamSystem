using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Exam
    {
        [Key]
        public int Exam_id { get; set; }

        [Display(Name ="Exam Name")]
        [MaxLength(20)]
        public string Exam_Name { get; set; }

        [Display(Name = "Exam Description")]
        [MaxLength(30)]
        public string Exam_Desc { get; set; }

        [Display(Name ="Exam Grade")]
        public Nullable<int> Exam_Grade { get; set; }

        public virtual ICollection<Student_exam> Student_Exams { get; set; }
        public virtual ICollection<ExamCourse> ExamCourses { get; set; }
        public virtual ICollection<Exam_Question> Exam_Questions { get; set; }


    }
}