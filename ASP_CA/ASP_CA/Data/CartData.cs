using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AspNetCore;
using ASP_CA.Models;

namespace ASP_CA.Data
{
    public class CartData : Data
    {
        public static void AddToCart(string ProductId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"Update Cart2
                                set quantity = quantity + 1
                                where productid = " + ProductId +
                                "Update Cart2 " +
                                "set totalprice = quantity * productprice";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }

        public static void ClearCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Cart2
                            SET Quantity = 0 
                            UPDATE Cart2
                            SET TotalPrice = 0";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static int QuantityCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT SUM(quantity) FROM Cart2";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                int x = (int)cmd.ExecuteScalar();
                return x;
            }
        }

        public static int TotalPrice()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT SUM(TotalPrice) FROM Cart2";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int x = (int)cmd.ExecuteScalar();
                return x;
            }
        }

        /*public static List<CartProduct> ViewCart()
        {
            List<Product> products = ProductData.GetAllProducts();

            List<CartProduct> cartProducts = new List<CartProduct>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT ProductId, ProductPrice, Quantity, TotalPrice from Cart2";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if ((int)reader["Quantity"] != 0)
                    {
                        foreach (var product in products)
                        {
                            if (product.ProductId == (int)reader["ProductId"])
                            {
                                string productName = product.ProductName;
                                string productDesc1 = product.ProductDesc;

                                CartProduct cartProduct = new CartProduct()
                                {
                                    ProductId = (int)reader["ProductId"],
                                    ProductPrice = (int)reader["ProductPrice"],
                                    ProductQuantity = (int)reader["Quantity"],
                                    ProductTotal = (int)reader["TotalPrice"],
                                    ProductName = productName,
                                    ProductDesc = productDesc1

                                };cartProducts.Add(cartProduct);
                            }
                        }
                    }
                    
                }return cartProducts;
            }
        }*/

    }
}
