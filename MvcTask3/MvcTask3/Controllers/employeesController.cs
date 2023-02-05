using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTask3.Models;

namespace MvcTask3.Controllers
{
    public class employeesController : Controller
    {
        private Task3Entities db = new Task3Entities();

        // GET: employees
        public ActionResult Index()
        {
            return View(db.employees.ToList());
        }
        [HttpPost]
        public ActionResult Index(string search, string SearchType)
        { switch (SearchType)
                        
            {
                case "1":   return View(db.employees.Where(employee => employee.first_Name.Contains(search)).ToList());
                case "2": return View(db.employees.Where(employee => employee.last_Name.Contains(search)).ToList());
                case "3": return View(db.employees.Where(employee => employee.Email.Contains(search)).ToList());
                default: return View(db.employees.ToList());
            }
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "first_Name,last_Name,Email,Phone,age,Job_Title,Gender,id,user_image,Cv")] employee employee,HttpPostedFileBase user_image,HttpPostedFileBase Cv)
        {
            if (ModelState.IsValid)
            {
                string path = "../Images/"+user_image.FileName;
                user_image.SaveAs(Server.MapPath(path));
                employee.user_image = path;
                string CvPath = "../Cvs/" + Cv.FileName;
                Cv.SaveAs(Server.MapPath(CvPath));
                employee.Cv = CvPath;
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "first_Name,last_Name,Email,Phone,age,Job_Title,Gender,id,user_image,Cv")] employee employee, HttpPostedFileBase user_image, HttpPostedFileBase Cv)
        {
            if (ModelState.IsValid)
            {
                var existingModel = db.employees.AsNoTracking().FirstOrDefault(x => x.id == id);

                if (user_image != null)
                {
                    string path = "../../Images/" + user_image.FileName;
                    user_image.SaveAs(Server.MapPath(path));
                    employee.user_image = path;
                }
                else
                {
                    employee.user_image = existingModel.user_image;
                }
                if (Cv != null)
                {
                    string CvPath = "../../Cvs/" + Cv.FileName;
                    Cv.SaveAs(Server.MapPath(CvPath));
                    employee.Cv = CvPath;
                }
                else
                {
                    employee.Cv = existingModel.Cv;
                }


                db.Entry(employee).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
