using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Data
{
    public class Activation : Data
    {
        public static void InsertActivationCode(int orderid, int userid, int product, string timestamp, string activationcode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO [Order] VALUES (@OrderId, @UserId, @ProductId, @Timestamp, @ActivationCode)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@OrderId", orderid);
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@ProductId", product);
                cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                cmd.Parameters.AddWithValue("@ActivationCode", activationcode);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return;
        }
    }
}
