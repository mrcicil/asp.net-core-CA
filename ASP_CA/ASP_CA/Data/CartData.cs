using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASP_CA.Data
{
    public class CartData : Data
    {
        public static void AddToCart(int userid, int ProductId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Cart (UserId, ProductId)
                            VALUES (@UserId, @ProductId)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@ProductId", ProductId);

                cmd.ExecuteNonQuery();
            }




        }

        public static void ClearCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"DELETE FROM Cart";

                SqlCommand cmd = new SqlCommand(sql, conn);

             

                cmd.ExecuteNonQuery();
            }




        }

    }
}
