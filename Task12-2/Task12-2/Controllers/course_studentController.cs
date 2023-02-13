using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task12_2.Models;

namespace Task12_2.Controllers
{
    public class course_studentController : Controller
    {
        private Entities db = new Entities();

        // GET: course_student
        public ActionResult Index()
        {
            var course_student = db.course_student.Include(c => c.Cours).Include(c => c.Student);
            return View(course_student.ToList());
        }

        // GET: course_student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_student course_student = db.course_student.Find(id);
            if (course_student == null)
            {
                return HttpNotFound();
            }
            return View(course_student);
        }

        // GET: course_student/Create
        public ActionResult Create()
        {
            ViewBag.Course_id = new SelectList(db.Courses, "id", "courseName");
            ViewBag.Student_id = new SelectList(db.Students, "id", "username");
            return View();
        }

        // POST: course_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Student_id,Course_id")] course_student course_student)
        {
            if (ModelState.IsValid)
            {
                db.course_student.Add(course_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_id = new SelectList(db.Courses, "id", "courseName", course_student.Course_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "username", course_student.Student_id);
            return View(course_student);
        }

        // GET: course_student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_student course_student = db.course_student.Find(id);
            if (course_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Courses, "id", "courseName", course_student.Course_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "username", course_student.Student_id);
            return View(course_student);
        }

        // POST: course_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Student_id,Course_id")] course_student course_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Courses, "id", "courseName", course_student.Course_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "username", course_student.Student_id);
            return View(course_student);
        }

        // GET: course_student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_student course_student = db.course_student.Find(id);
            if (course_student == null)
            {
                return HttpNotFound();
            }
            return View(course_student);
        }

        // POST: course_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course_student course_student = db.course_student.Find(id);
            db.course_student.Remove(course_student);
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
