using System.Web.Mvc;
using Task3.Models;

namespace Task3.Controllers
{
    public class StudentController : Controller
    {
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
                //db insertion or authentication authorization
                return RedirectToAction("Index","Student");
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Index()
        {
            return View();
            /*if (ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Create");*/
            /*ViewBag.Name = Request["Name"];
            ViewBag.Id = Request["Id"];
            ViewBag.Dob = Request["Dob"];
            ViewBag.Email = Request["Email"];*/

            /*ViewBag.Name = form["Name"];
            ViewBag.Id = form["Id"];
            ViewBag.Dob = form["Dob"];
            ViewBag.Email = form["Email"];*/
            /*ViewBag.Name = Name;
            ViewBag.Id = Id;
            ViewBag.Dob = Dob;
            ViewBag.Email = Email;*/
        }


    }
}