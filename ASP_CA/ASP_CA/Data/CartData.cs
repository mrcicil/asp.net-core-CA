using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

    }
}
