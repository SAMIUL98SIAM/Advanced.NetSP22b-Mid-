using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4.Models.Database;

namespace Task4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            sp22BEntities4 db = new sp22BEntities4();
            return View(db.Students.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                sp22BEntities4 db = new sp22BEntities4();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            sp22BEntities4 db = new sp22BEntities4();
            var student = (from b in db.Students where b.Id == id select b).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student sub_student)
        {
            sp22BEntities4 db = new sp22BEntities4();
            var student = (from b in db.Students where b.Id == sub_student.Id select b).FirstOrDefault();
            db.Entry(student).CurrentValues.SetValues(sub_student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ScholarshipList()
        {
            sp22BEntities4 db = new sp22BEntities4();
            var student = from p in db.Students where p.Cgpa >= 3.75 select p;
            return View(student.ToList());
        }

        public ActionResult DiscountList()
        {
            sp22BEntities4 db = new sp22BEntities4();
            DateTime today = DateTime.Today;
            DateTime min = today.AddYears(-30);
            var DUsers = db.Students.Where(e => e.Dob != null && e.Dob <= min);
            return View(DUsers.ToList());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            sp22BEntities4 db = new sp22BEntities4();
            var student = (from b in db.Students where b.Id == id select b).FirstOrDefault(); ;
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student sub_student)
        { 
            sp22BEntities4 db = new sp22BEntities4();
            var student = (from b in db.Students where b.Id == sub_student.Id select b).FirstOrDefault(); ;
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    
}