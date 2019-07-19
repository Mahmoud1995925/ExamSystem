using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination_system.Models
{
    public class Calc_total
    {
        public List<validateAnswers> User_Answer { get; set; }
        public int total { get; set; }
        public void set_Correct_data()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (validateAnswers validate in User_Answer)
            {
                validate.question = dbContext.Questions.FirstOrDefault(c => c.Question_id == validate.question_id);
                validate.Correct_ans = dbContext.answers.FirstOrDefault(c => c.Answer_id == validate.correct_answer_id);
                if (validate.user_answer_id == 0)
                {
                    validate.usr_ans = null;
                }
                else
                {
                    validate.usr_ans = dbContext.answers.FirstOrDefault(c => c.Answer_id == validate.user_answer_id);
                }
            }
        }
        public void calculat_total()
        {
            total = 0;
            foreach (validateAnswers validate in User_Answer)
            {
                if (validate.correct_answer_id == validate.user_answer_id)
                {
                    total += validate.question.Question_Grade.Value;
                }

            }
        }
       
    }
}