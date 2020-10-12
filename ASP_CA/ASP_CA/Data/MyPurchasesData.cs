using ASP_CA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Data
{
    public class MyPurchasesData : Data
    {
        public static List<MyPurchases> GetAllMyPurchases()
        {
            List<MyPurchases> myPurchases = new List<MyPurchases>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"select p.Productname, o.ProductId, o.ActivationCode, o.Timestamp, o.OrderId
                                from [order] o , product p
                                where o.ProductId = p.ProductId
                                and o.UserId = 1 order by o.Timestamp desc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MyPurchases myPurchase = new MyPurchases()
                    {
                        OrderID = (int)reader["OrderId"],
                        ProductID = (int)reader["ProductId"],
                        ProductName = (string)reader["ProductName"],
                        PurchasedOn = (string)reader["Timestamp"],
                        ActivationCode = (string)reader["ActivationCode"],
                    };
                    myPurchases.Add(myPurchase);
                }
                
            }

            return myPurchases;
        }
    }
}
