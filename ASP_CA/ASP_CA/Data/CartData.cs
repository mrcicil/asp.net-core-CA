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

        public static void AddToTempCart(int ProductId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO TempCart (ProductId)
                            VALUES (@ProductId)";

                SqlCommand cmd = new SqlCommand(sql, conn);

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

        public static void ClearTempCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"DELETE FROM TempCart";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static int QuantityCart(string userid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Cart WHERE UserId = " + userid;
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                int x = (int)cmd.ExecuteScalar();
                return x;
            }
        }

        public static int QuantityTempCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM TempCart";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int x = (int)cmd.ExecuteScalar();
                return x;
            }
        }

    }
}
