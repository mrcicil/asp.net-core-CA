using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using System.Data.SqlClient;
using ASP_CA.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_CA.Controllers
{
    public class MyPurchasesController : Controller
    {
        protected static readonly string connectionString = "data source=.; Database=ASP_CA; Integrated Security=true";
        public Sessions sessions;

        public MyPurchasesController(Sessions sessions)
        {
            this.sessions = sessions;
        }

        // GET: MyPurchasesController
        public ActionResult Index()
        {
            return View();
        }


        //POST from cart to push data into Order table
        [HttpPost]
        public ActionResult PurchaseInformation(List<int>product, List<int>amount, [FromServices]Sessions sessions)
        {
            Session session = null;
            string sessionId = HttpContext.Request.Cookies["sessionId"];

            ViewData["sessionId"] = sessionId;

            if (sessionId == null)
            {
                var o = new { error = "Please login before checking out" };
                return RedirectToAction("Index", "Gallery", o);
            }
            else
                sessions.map.TryGetValue(sessionId, out session);

            ViewData["product"] = product;
            ViewData["amount"] = amount;

            int userid = session.UserId;
            string timestamp = DateTime.Now.ToString();
            int orderid = OrderData.GetLastOrderId() + 1;

            List<string> codelist = new List<string>();


            for (int i=0; i<product.Count; i++)
            {
                for (int j=0; j<amount[i] && amount[i] !=0; j++)
                {
                    string code = Guid.NewGuid().ToString();
                    string activationcode = code.Substring(3, 12);

                    codelist.Add(activationcode);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO [Order] VALUES (@OrderId, @UserId, @ProductId, @Timestamp, @ActivationCode)";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@OrderId", orderid);
                        cmd.Parameters.AddWithValue("@UserId", userid);
                        cmd.Parameters.AddWithValue("@ProductId", product[i]);
                        cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationcode);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                
            }

            ViewData["codelist"] = codelist;
            ViewData["userid"] = userid;
            ViewData["orderid"] = orderid;
            ViewData["timestamp"] = timestamp;

            return View("PurchaseInfo");
        }

        // GET: MyPurchasesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyPurchasesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPurchasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPurchasesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPurchasesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPurchasesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyPurchasesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
