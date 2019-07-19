using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examination_system.Models;

namespace Examination_system.Controllers
{
    [Authorize]
    public class ProblemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Problems
        public ActionResult Index()
        {
            ViewBag.msg = "we Can't Find What you are Looking For";
            return View();
        }

        // GET: Problems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult rebortProblem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult save(Problem pro)
        {
            string id = Session["userId"].ToString();
            pro.User_id = id;
            ApplicationUser usr = db.Users.FirstOrDefault(c=>c.Id==id);
            pro.Student = usr;
            if (ModelState.IsValid)
            {
                db.problems.Add(pro);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("rebortProblem");
            }

            return RedirectToAction("index", "student");
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Problem_id,Problem_Desc,User_id")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.problems.Add(problem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problem);
        }

        // GET: Problems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Problem_id,Problem_Desc,User_id")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problem);
        }

        // GET: Problems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.problems.Find(id);
            db.problems.Remove(problem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
