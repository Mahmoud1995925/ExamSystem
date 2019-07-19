using Examination_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examination_system.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*ApplicationDbContext context = new ApplicationDbContext();
          //  List<ApplicationUser> students = context.Users.ToList();
           
            List<Exam> exams = context.Exams.ToList();*/
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}