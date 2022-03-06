using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EccomerceClassWork.Models.Entities
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }

        public CustomerModel Customer { get; set; }
    }
}