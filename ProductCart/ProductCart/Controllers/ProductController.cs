using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductCart.Models;
using ProductCart.Models.Entity;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data.Entity;

namespace ProductCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            productCartEntities2 db = new productCartEntities2();
            return View(db.Products.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productCartEntities2 db = new productCartEntities2();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {

            productCartEntities2 db = new productCartEntities2();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product sub_product)
        {

            productCartEntities2 db = new productCartEntities2();
            var product = (from p in db.Products where p.Id == sub_product.Id select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(sub_product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            productCartEntities2 db = new productCartEntities2();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault(); ;
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product sub_product)
        {

            productCartEntities2 db = new productCartEntities2();
            var product = (from p in db.Products where p.Id == sub_product.Id select p).FirstOrDefault(); ;
            //db.Entry(book).Books.Remove(sub_book);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            productCartEntities2 db = new productCartEntities2();
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();
            return View(product);
        }


        /*[HttpGet]
        public ActionResult AddToCart(int id)
        {
            productCartEntities2 db = new productCartEntities2();

            //var product = db.Products.Get(id);
            var product = (from p in db.Products where p.Id == id select p).FirstOrDefault();

            return View(product);
        }*/

       
        public ActionResult AddToCart(int id)
        {
            Models.Database db = new Models.Database();
            var product = db.Products.Get(id);

            if (Session["cart"] == null)
            {
                List<Product> tempcart = new List<Product>();
                tempcart.Add(product);
                Session["cart"] = JsonConvert.SerializeObject(tempcart);

            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                d.Add(product);
                Session["cart"] = JsonConvert.SerializeObject(d);
                System.Diagnostics.Debug.WriteLine(Session["cart"]);
            }
            return RedirectToAction("Cart");
        }



        public ActionResult Cart()
        {
            if (Session["cart"] == null)
            {
                return View(new List<Product>());
            }
            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>(Session["cart"].ToString());
                return View(d);
            }

        }



    }

   
}