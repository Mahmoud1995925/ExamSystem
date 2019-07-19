using Examination_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examination_system.Controllers
{
    [Authorize]
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exams
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Exams.ToList());

            }
            return RedirectToAction("Login", "Account");
        }

        // GET: Exams/Details/5
        public ActionResult Studentexams()
        {
            string id = Session["userId"].ToString();
            ApplicationUser student = db.Users.FirstOrDefault(c => c.Id == id);
            return View(student.Student_Exams);
        }
       
        // GET: Exams/Create
        public ActionResult Create(int id)
        {
            try
            {
                Student_exam student_Exam = new Student_exam();
                student_Exam.exam = db.Exams.FirstOrDefault(c => c.Exam_id == id);
                student_Exam.Exam_id = id;
                string Id = Session["userId"].ToString();
                student_Exam.User = db.Users.FirstOrDefault(c => c.Id == Id);
                student_Exam.UserId = Id;
                db.student_Exams.Add(student_Exam);               
                db.SaveChanges();
                return RedirectToAction("GetExamQuestions", new { id = id });
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetExamQuestions", new { id =id });
            }
        }

        // POST: Exams/Create
        public ActionResult GetExamQuestions(int id)
        {
            Session["examid"] = id;
            try
            {

               List<Exam_Question> exams = db.Exam_Questions.Where(ex => ex.Exam_id == id).ToList();
                UserAnswer answer = new UserAnswer();
                answer.Exam_Questions = exams;
                return View(answer);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Exams/Edit
        [HttpPost]
        public ActionResult save( UserAnswer usrans)
        {
            
            Calc_total calc_ = new Calc_total();
            calc_.User_Answer = usrans.User_Answer;
            calc_.set_Correct_data();
            calc_.calculat_total();

            Student_exam student_Exam = new Student_exam();
            student_Exam.Exam_id = int.Parse(Session["examid"].ToString());
            string Id = Session["userId"].ToString();
            student_Exam.UserId = Id;
            student_Exam.User = db.Users.FirstOrDefault(c => c.Id == student_Exam.UserId);
            student_Exam.exam = db.Exams.FirstOrDefault(c => c.Exam_id == student_Exam.Exam_id);
            Student_exam studentExam = db.student_Exams.FirstOrDefault(c => (c.Exam_id == student_Exam.Exam_id && c.UserId == student_Exam.UserId));
            student_Exam.Grade = calc_.total;
            if (studentExam == null)
            {
                db.student_Exams.Add(student_Exam);
            }
            else
            {
                studentExam.Grade = calc_.total;
            }

            db.SaveChanges();
            return View(calc_);
        }
       

        // POST: Exams/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            string usrid = Session["userId"].ToString();
            try
            {
                Student_exam st_Exam = db.student_Exams.First(c => (c.Exam_id == id && c.UserId == usrid));
                db.student_Exams.Remove(st_Exam);
                db.SaveChanges();
                return RedirectToAction("Studentexams");
            }
            catch (Exception e)
            {
                return Content("Can't remove this course");
            }
        }

        // POST: Exams/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
