using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp2084Winter2022Thursday.Models;

namespace comp2084Winter2022Thursday.Controllers
{
    public class SemestersController : Controller
    {
        private DataContext db = new DataContext();



        public ActionResult Year(int year) {

            var listsOfNames = new List<string> { 
            "Ben Blanc",
            "Sarah O'Connor",
            "Prof",
            "Mary",
            "sally-Sally"
            };

            //lambda expression
            // placeholder represents a record of data => methods or actions
         var subList =   listsOfNames.Where(s => s.Length < 5).ToList();

            var listOfLogins = new List<Login> { 
                new Login(){ Username = "ben@blanc.ca", Password="hello", ConfirmPassword = "hello", RememberMe = true},
                new Login(){ Username = "blanc@ben.ca", Password="goodbye", ConfirmPassword = "goodbye", RememberMe = false},
                new Login(){ Username = "comp@gc.ca", Password="comp2084", ConfirmPassword = "comp2084", RememberMe = true},
            };

            var secondSubList = listOfLogins
                                .Where(s => s.Username.Length > 5 && s.Password.Length <= 5)
                                .Select(s => s.Username)
                                .ToList();
            ViewBag.SubList = secondSubList;

            //with quick tutorial of LINQ
            //TASK: query the Semester table of the database
            // get/retrieve only the YEAR field WHERE the year is equal to the value passed
            // refer to tutorial above AND index method
            //you do not need to pass to the view yet. just retrieve the list of info

            var semestersOfYears = db
                                    .Semesters
                                    .Where(s => s.Year == year)
                                    .OrderBy(s => s.Term)
                                    .Select(s => s.Term);
                                    

            ViewBag.Year = year;

            return View(semestersOfYears.ToList());
        }

        public ActionResult Term(int year, string term) {

            //query the database to get all record information (including joining tables)
            //for all records that have the specified year and term (passed as param)


            /*
             *SQL
             *      select
             *      where
             *      
             *      joins
             *
             *LINQ
             *  
             *      where
             *      select
             *      include
             *
             */ 

            var allRecords = db
                                .Semesters
                                .Where(s => s.Year == year && s.Term == term)
                                .Include(s => s.Cours)
                                .Include(s => s.Prof)
                                .Include(s => s.Student);

            return View(allRecords.ToList());

        }

        // GET: Semesters
        public ActionResult Index()
        {
            var semesters = db.Semesters
                .Include(s => s.Cours)
                .Include(s => s.Prof)
                .Include(s => s.Student);
            //LINQ
            /*
             * Language 
             * INtegrated
             * Query
             * 
             */ 
            return View(semesters.ToList());
        }

        // GET: Semesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // GET: Semesters/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "FirstName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterID,Term,Year,CourseID,ProfID,StudentID")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Semesters.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "FirstName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "FirstName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterID,Term,Year,CourseID,ProfID,StudentID")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "FirstName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester semester = db.Semesters.Find(id);
            db.Semesters.Remove(semester);
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
