using _7_2Task.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7_2Task.Controllers
{
    public class HomeController : Controller
    {
        Task3Entities db= new Task3Entities();
        public ActionResult Index()
        {
            var emp = db.employees.ToList();
            return View(emp);
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
    }
}