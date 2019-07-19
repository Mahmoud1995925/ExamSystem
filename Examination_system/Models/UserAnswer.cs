using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class UserAnswer
    {

        public List<Exam_Question> Exam_Questions { get; set; }
        
        public List<validateAnswers> User_Answer { get; set; }
       


    }
}