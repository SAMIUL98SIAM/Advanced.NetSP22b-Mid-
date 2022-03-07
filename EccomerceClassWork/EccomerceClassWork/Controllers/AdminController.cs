using AutoMapper;
using EccomerceClassWork.Auth;
using EccomerceClassWork.Models.Database;
using EccomerceClassWork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace EccomerceClassWork.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            EcommerceEntities db = new EcommerceEntities();
            var orders = db.Orders.ToList();
            var config = new MapperConfiguration(cfg=>
                {
                    cfg.CreateMap<Order, OrderModel>();
                    cfg.CreateMap<Customer, CustomerModel>();
                }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderModel>>(orders);
            return View(data);
        }

        public ActionResult Process(int id)
        {
            EcommerceEntities db = new EcommerceEntities();
            var order = (from o in db.Orders 
                         where o.Id == id select o).FirstOrDefault();
            order.Status = "Processing";
            foreach (var od in order.OrderDetails)
            {
                var orderedQty = od.Qty;
                od.Product.Qty -= orderedQty;
            }
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ActionResult Cancel(int id)
        {
            EcommerceEntities db = new EcommerceEntities();
            var order = (from o in db.Orders
                         where o.Id == id
                         select o).FirstOrDefault();
            if(order.Status == "Processing")
            {
                foreach (var od in order.OrderDetails)
                {
                    var orderQty = od.Qty;
                    od.Product.Qty += orderQty;
                }
            }
            order.Status = "Cancelled";
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}