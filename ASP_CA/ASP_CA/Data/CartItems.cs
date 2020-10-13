using ASP_CA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Data
{
    public class CartItems : Data
    {
        //public static List<Product> AddToCart()
        //{

        //}
        public static List<Cart> GetCartItems(int userId)
        {
            List<Cart> cartItems = new List<Cart>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // inner join of dbo.Cart & Product
                string sql = @"SELECT Cart.ProductId, Product.ProductName, 
                                Product.ProductDesc, Product.ProductPrice, Cart.Quantity
                            FROM Cart, Product
                            WHERE Cart.ProductId = Product.ProductId
                            AND Cart.UserId = " + userId;

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cart item = new Cart()
                    {
                        UserId = (int)userId,
                        ProductId = (int)reader["ProductId"],
                        ProductName = (string)reader["ProductName"],
                        ProductDesc = (string)reader["ProductDesc"],
                        ProductPrice = (int)reader["ProductPrice"],
                        Quantity = (int)reader["Quantity"]
                    };
                    cartItems.Add(item);
                }
            }
            return cartItems;


            //List<Cart> myCartList = new List<Cart>();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    string sql = @"SELECT Cart.ProductId, Product.ProductName, 
            //                    Product.ProductDesc, Product.ProductPrice
            //                FROM Cart, Product
            //                WHERE Cart.ProductId = Product.ProductId
            //                AND Cart.UserId = " + userId +
            //                "GROUP BY Cart.ProductId" +

            //                @"SELECT count(Cart.ProductId) as Quantity
            //                        FROM Cart
            //                        WHERE Cart.UserId = " + userId +
            //                        "GROUP BY Cart.ProductId";

            //    SqlCommand cmd = new SqlCommand(sql, conn);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Cart cartItem2 = new Cart()
            //        {
            //            UserId = (int)userId,
            //            ProductId = (int)reader["ProductId"],
            //            ProductName = (string)reader["ProductName"],
            //            ProductDesc = (string)reader["ProductDesc"],
            //            ProductPrice = (int)reader["ProductPrice"],
            //            Quantity = (int)reader["Quantity"]
            //        };
            //        myCartList.Add(cartItem2);
            //    }
            //}
        }
    }
}
