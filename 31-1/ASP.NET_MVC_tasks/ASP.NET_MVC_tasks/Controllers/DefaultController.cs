using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ASP.NET_MVC_tasks.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public string download() {
            var imgPath = Server.MapPath("../Images/Harry.png");
            Response.AddHeader("Content-Disposition", "attachment;filename=DealerAdTemplate.png");
            Response.WriteFile(imgPath);
            Response.End();
            return null;
        }
        public string Index()
        {

            return "<a href=\"download\"><img src=\"../Images/Harry.png\" onclick=\"download\" /><a/>";
        }
        public string ContactUs()
        {

            return "<h1>Hello<h1/>";
        }
        public string AboutUs()
        {

            return "<h1>Bye<h1/>";
        }
    }
}