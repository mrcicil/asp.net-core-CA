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
                string sql = @"SELECT Product.ProductId, Product.ProductName, Product.ProductDesc, Product.ProductPrice
                                FROM Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = (string)reader["ProductName"],
                        //testing testing
                        ProductDesc = (string)reader["ProductDesc"],
                        ProductPrice = (int)reader["ProductPrice"]
                    };
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
