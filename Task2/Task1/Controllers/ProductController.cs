using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product() { 
                    Name = "Product No" + (i+1),
                    Id = i+1
                });

            }
            return View(products);
        }
    }
}