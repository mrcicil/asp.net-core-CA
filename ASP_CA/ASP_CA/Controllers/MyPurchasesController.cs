using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using System.Data.SqlClient;

namespace ASP_CA.Controllers
{
    public class MyPurchasesController : Controller
    {
        private readonly User user;
        protected static readonly string connectionString = "data source=.; Database=ASP_CA; Integrated Security=true";

        public MyPurchasesController(User user)
        {
            this.user = user;
        }

        // GET: MyPurchasesController
        public ActionResult Index()
        {
            return View();
        }


        //POST from cart to push data into Order table
        [HttpPost]
        public ActionResult PurchaseInformation(List<int>product)
        {
            ViewData["product"] = product;
            string userid = user.UserId;

            string order = Guid.NewGuid().ToString();
            string orderid = "OR000" + order.Substring(0, 7);

            List<string> codelist = new List<string>();

            foreach (int id in product)
            {
                string code = Guid.NewGuid().ToString();
                string activationcode = code.Substring(3, 12);

                codelist.Add(activationcode);

                /*
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                            INSERT INTO Order (OrderId, UserId, ProductId, Timestamp, ActivationCode)
                            VALUES (@OrderId, @UserId, @ProductId, @Timestamp, @ActivationCode)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderId", orderid);
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    cmd.Parameters.AddWithValue("@Timestamp", null);
                    cmd.Parameters.AddWithValue("@ActivationCode", activationcode);

                    cmd.ExecuteNonQuery();
                }*/
            }

            ViewData["codelist"] = codelist;
            ViewData["userid"] = userid;
            ViewData["orderid"] = orderid;

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
