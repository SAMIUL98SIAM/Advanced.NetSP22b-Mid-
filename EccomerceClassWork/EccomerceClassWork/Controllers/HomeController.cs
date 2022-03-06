using EccomerceClassWork.Models.Database;
using EccomerceClassWork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EccomerceClassWork.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var db = new EcommerceEntities();
                var u = new User();
                
                Customer customer = new Customer();

                u.Password = user.Password;
                u.Username = user.Username;
                u.Type = "Customer";
                db.Users.Add(u);
                db.SaveChanges();

                var cus = new Customer();
                cus.UserId = u.Id;
                cus.Name = u.Username;
                cus.Password = u.Password;
                cus.Phone = customer.Phone;
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Registration");
                
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var db = new EcommerceEntities();
                var u = (from e in db.Users where e.Username.Equals(user.Username) && 
                         e.Password.Equals(user.Password) select e).FirstOrDefault();
                if (u != null)
                {
                    Session["UserName"] = u.Username;
                    Session["UserType"] = u.Type;
                    if(u.Type.Equals("Customer"))
                    {
                        //Customer Dashboard
                    }
                    else if(u.Type.Equals("Admin"))
                    {
                        //Admin Dashboard
                        return RedirectToAction("Dashboard", "Admin");
                    }
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}