using ASP_CA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Data
{
    public class OrderData : Data
    {
        public static int GetLastOrderId()
        {
            Order order = new Order();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT Top 1 orderid FROM [ORDER] ORDER BY orderid DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    order.OrderId = (int)reader["OrderId"];
                }
            }

            return order.OrderId;
        }
    }
}
