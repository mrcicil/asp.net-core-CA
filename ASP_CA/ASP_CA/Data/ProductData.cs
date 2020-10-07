using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ASP_CA.Models;

namespace ASP_CA.Data
{
    public class ProductData : Data
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT Product.ProductName, Product.ProductId
                                FROM Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        
                        ProductName = (string)reader["ProductName"],
                        ProductId = (int)reader["ProductId"]

                    };
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
