using AutoMapper;
using EccomerceClassWork.Models.Database;
using EccomerceClassWork.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace EccomerceClassWork.Controllers
{
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
    }
}