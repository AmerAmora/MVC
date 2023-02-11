using AuthorizTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizTask.Controllers
{
    [Authorize]   
    
    public class HomeController : Controller
    {
        Task3Entities db = new Task3Entities();
        public ActionResult Index()
        {
            var emp = db.employees.ToList();
            return View(emp);
        }

        [Authorize(Roles="Admin")]

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
    }
}