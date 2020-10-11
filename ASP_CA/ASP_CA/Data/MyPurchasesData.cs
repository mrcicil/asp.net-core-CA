using ASP_CA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ASP_CA.Data
{
    public class MyPurchasesData : Data
    {
        public static List<MyPurchase> GetAllData(string UserId)
        {
            List<MyPurchase> myPurchases = new List<MyPurchase>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT ProductId, ProductName, Timestamp, ActivationCode
                                FROM Order1 where UserId = " + UserId + " order by ProductName,Timestamp";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MyPurchase myPurchase = new MyPurchase()
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = (string)reader["ProductName"],
                        TimeStamp = (string)reader["Timestamp"],
                        ActivationCode = (string)reader["ActivationCode"]
                    };
                    myPurchases.Add(myPurchase);
                }
            }

            return myPurchases;
        }

        public static List<SummariseMyPurchase>GetSummaryData(string userId)
        {
            List<SummariseMyPurchase> summariseMyPurchases = new List<SummariseMyPurchase>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"select ProductName, Timestamp, Count(*) as Quantity
                                from Order1
                                where UserId = " + userId + "group by productname, timestamp";
                                
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    SummariseMyPurchase summariseMyPurchase = new SummariseMyPurchase()
                    {
                        
                        ProductName = (string)reader["ProductName"],
                        Timestamp = (string)reader["Timestamp"],
                        Quantity = (int)reader["Quantity"]
                    };
                    summariseMyPurchases.Add(summariseMyPurchase);
                }
            }

            return summariseMyPurchases;
        }
    }
    
    
}
