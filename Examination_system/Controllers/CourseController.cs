using Examination_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examination_system.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Course
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.courses.ToList());

            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult registercourse(int Course_id)
        {
           
                try
                {
                    Student_course student_Course = new Student_course();
                    student_Course.UserId = Session["userId"].ToString();
                    student_Course.Course_id = Course_id;
                    student_Course.Course = db.courses.FirstOrDefault(c => c.Course_id == student_Course.Course_id);
                    student_Course.User = db.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
                    if (db.student_Courses.Any(sC => sC.Course_id == student_Course.Course_id && sC.UserId == student_Course.UserId))
                    {
                        ViewBag.msg = "You Already Signed in this Course";
                        return View();
                    }
                    db.student_Courses.Add(student_Course);
                    db.SaveChanges();
                    ViewBag.msg = "Course Added Successfully.";
                    return View();

                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }

            
        }
        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = db.courses.FirstOrDefault(c=>c.Course_id==id);
            if (course == null)
            {
                return RedirectToAction("Index", "Problems");
            }
            return View(course);
        }
        public ActionResult Student_courses()
        {
            string id = Session["userId"].ToString();
            ApplicationUser student = db.Users.FirstOrDefault(c => c.Id == id);

            return View(student);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
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

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            string usrid = Session["userId"].ToString();
            try
            {
                Student_course student_Course = db.student_Courses.First(c => (c.Course_id == id && c.UserId == usrid));
                if (student_Course == null)
                {
                    return RedirectToAction("Index", "Problems");

                }
                db.student_Courses.Remove(student_Course);
                db.SaveChanges();
                return RedirectToAction("Student_courses");
            }
            catch (Exception e)
            {
                return Content("Can't remove this course");
            }
        }

        // POST: Course/Delete/5
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
