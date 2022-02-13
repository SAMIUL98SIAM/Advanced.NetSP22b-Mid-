using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ProductCart.Models.Entity;


namespace ProductCart.Models.Repository
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product p)
        {
            conn.Open();
            string query = String.Format("insert into [dbo].[Products] ([Name],[Qty],[Price] values ('{0}','{1}','{2}','{3}')", p.Name, p.Qty, p.Price);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product> Get()
        {
            conn.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = Convert.ToInt32(reader["Qty"]),
                    Price = Convert.ToDouble(reader["Qty"]),
                };
                products.Add(p);
            }

            conn.Close();
            return products;
        }
        public Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product product = null;

            while (reader.Read())
            {
                product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = Convert.ToInt32(reader["Qty"]),
                    Price = Convert.ToDouble(reader["Price"])
                    
                };

            }
            conn.Close();
            return product;
        }
        public void Update(Product p)
        {
            conn.Open();
            string query = String.Format("UPDATE [dbo].[Products] SET [Name]='{0}',[Qty]={1},[Price]='{2}' WHERE [id]='{3}'", p.Name, p.Qty, p.Price, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            conn.Open();
            string query = String.Format("DELETE FROM [dbo].[Products] WHERE [Id]='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}