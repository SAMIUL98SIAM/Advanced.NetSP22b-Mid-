using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProductCart.Models.Repository;

namespace ProductCart.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Database()
        {
            string conString = @"Data Source=DESKTOP-OOSIQJJ\SQLEXPRESS;Initial Catalog=productCart;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            conn = new SqlConnection(conString);
            Products = new Products(conn);
           
        }
       

    }
}