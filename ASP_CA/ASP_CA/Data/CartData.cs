using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ASP_CA.Models;
using Microsoft.AspNetCore.Mvc;

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

        public static List<CartProduct> ViewCart()
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
                                CartProduct cartProduct = new CartProduct()
                                {
                                    ProductId = (int)reader["ProductId"],
                                    ProductPrice = (int)reader["ProductPrice"],
                                    ProductQuantity = (int)reader["Quantity"],
                                    ProductTotal = (int)reader["TotalPrice"],
                                    ProductName = product.ProductName,
                                    ProductDesc = product.ProductDesc

                                };cartProducts.Add(cartProduct);
                            }
                        }
                    }
                    
                }return cartProducts;
            }
        }

        public static void PlusOneInCart(string productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE [Cart2] 
                             SET Quantity = Quantity + 1
                              WHERE ProductId = " + productId +
                              "UPDATE [Cart2] " +
                               "SET TotalPrice = Quantity * ProductPrice " +
                               "WHERE ProductId = " + productId;
                
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void MinusOneInCart(string productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Cart2 
                             SET Quantity = Quantity - 1
                              WHERE ProductId = " + productId +
                              "UPDATE Cart2 " +
                               "SET TotalPrice = Quantity * ProductPrice " +
                               "WHERE ProductId = " + productId;

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public static void RemoveInCart(string productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Cart2 
                             SET Quantity = 0
                              WHERE ProductId = " + productId +
                              "UPDATE Cart2 " +
                               "SET TotalPrice = Quantity * ProductPrice " +
                               "WHERE ProductId = " + productId;

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void CheckOut(int userId,CartProduct cartProduct)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"insert into Order1 (UserId, ProductId, ProductName, Timestamp, ActivationCode)
                             values (@UserId, @ProductId, @ProductName, @Timestamp, @ActivationCode)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ProductId", cartProduct.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", cartProduct.ProductName);
                cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now.ToString("d/MMM/yyyy"));
                cmd.Parameters.AddWithValue("@ActivationCode", Guid.NewGuid().ToString());

                cmd.ExecuteNonQuery();
            }
        }
    }
}
