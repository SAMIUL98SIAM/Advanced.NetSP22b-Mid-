using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4.Models.Database;

namespace Task4.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            sp22BEntities3 db = new sp22BEntities3();
            return View(db.Books.ToList());
        }

        public ActionResult Show()
        {
            sp22BEntities3 db = new sp22BEntities3();
            return View(db.Books.ToList());
        }
        
        public ActionResult HighPrice()
        {
            sp22BEntities3 db = new sp22BEntities3();
            var data = (from b in db.Books
                        where b.Price > 100
                        select b).ToList();
            return View(data);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Create(Book b)
        {
            if(ModelState.IsValid)
            {
                sp22BEntities3 db = new sp22BEntities3();
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            sp22BEntities3 db = new sp22BEntities3();
            var book = (from b in db.Books where b.Id == id select b).FirstOrDefault();   
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book sub_book)
        {

            sp22BEntities3 db = new sp22BEntities3();
            var book = (from b in db.Books where b.Id == sub_book.Id select b).FirstOrDefault();
            db.Entry(book).CurrentValues.SetValues(sub_book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            sp22BEntities3 db = new sp22BEntities3();
            var book = (from b in db.Books where b.Id == id select b).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(Book sub_book)
        {

            sp22BEntities3 db = new sp22BEntities3();
            var book = (from b in db.Books where b.Id == sub_book.Id select b).FirstOrDefault();
            //db.Entry(book).Books.Remove(sub_book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}