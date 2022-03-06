using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EccomerceClassWork.Models.Entities
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}