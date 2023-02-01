using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_tasks.Controllers
{
    public class AmerController : Controller
    {
        // GET: Amer
        public string Index()
        {
            return "Amer";
        }
        public string Age()
        {
            return "23";
        }
        public string Major()
        {
            return "ComputerScience";
        }
        public string Email()
        {
            return "Amer.m.amora@gmail.com";
        }
    }
}