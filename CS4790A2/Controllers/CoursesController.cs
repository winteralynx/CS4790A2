using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS4790A2.Models;

namespace CS4790A2.Controllers
{
    public class CoursesController : Controller
    {
        private BasicSchoolDbContext db = new BasicSchoolDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                CourseAndSections courseAndSections = Repository.getCourseAndSections(id); //NEED TO MODIFY TO GET THE COURSE AND SECTION INSTEAD OF JUST THE COURSE
                if (courseAndSections == null)
                {
                    return HttpNotFound();
                }
                return View(courseAndSections);
            //Course course = Repository.getCourse(id); //This will use the Repository instead of doing a direct data access
            //if (course == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(course);
        }

        ////This is a copy of the course details that returns a course and section instead 
        //public ActionResult CourseAndSections(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CourseAndSections courseAndSections = Repository.getCourseAndSections(id); //NEED TO MODIFY TO GET THE COURSE AND SECTION INSTEAD OF JUST THE COURSE
        //    if (courseAndSections == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(courseAndSections);
        //}

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,courseNumber,courseName,creditHours,maxEnrollment")] Course course)
        {
            if (ModelState.IsValid)
            {
                Repository.createCourse(course); //Changed from db.courses.Add(course);  db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = Repository.getCourse(id); //UPDATE from OLD: = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,courseNumber,courseName,creditHours,maxEnrollment")] Course course)
        {
            if (ModelState.IsValid)
            {
                Repository.updateCourse(course);  //UPDATE from OLD db.Entry(course).State = EntityState.Modified; db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = Repository.getCourse(id); //UPDATE from OLD: = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = Repository.getCourse(id); //UPDATE from OLD: = db.courses.Find(id);
            Repository.removeCourse(course);  // UPDATE from OLD db.courses.Remove(course); db.SaveChanges();
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
