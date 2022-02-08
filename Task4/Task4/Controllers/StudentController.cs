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
            sp22BEntities3 db = new sp22BEntities3();
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
                sp22BEntities3 db = new sp22BEntities3();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit()
        {
            return View(new Student());
        }


    }

    
}