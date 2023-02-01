using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _ASP.NET_MVC_tasks.Models;
namespace _ASP.NET_MVC_tasks.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {List <Student> students = new List <Student>();
            students.Add(new Student() {Id=1,Name="Amer",Major="Cs",Faculity="IT" });
            students.Add(new Student() { Id = 2, Name = "Momen", Major = "electricity engineering", Faculity = "Engineering" });

            return View(students);
        }
    }
}