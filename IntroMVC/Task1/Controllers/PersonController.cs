using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ind()
        {
            var person = new Person()
            {
                Name = "Salam",
                Id = 1,
                Dob = DateTime.Now
            };
            return View(person);
        }

        public ActionResult Home()
        {
            /*
            ViewBag.name = "Samiul";
            ViewBag.id = "18-38844-3";
            ViewBag.dob = "28-01-1998";

            ViewData["name"] = "Mumu";
            ViewData["id"] = "18-36765-1";
            ViewData["dob"] = "15-09-1998";

            string[] names = { "Siam", "Akib", "Razib", "Hasib" };
            ViewBag.names = names;
            */

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                var person = new Person()
                {
                    Name = "Persons" + (i + 1),
                    Id = (i + 1),
                    Dob = DateTime.Now
                };
                persons.Add(person);
            }
            
            return View(persons);
        }
    }
}