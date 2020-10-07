using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using System.Data.SqlClient;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace ASP_CA.Controllers
{
    public class CartController : Controller
    {
        /*string connectionString =
            "Server = (local);" +
            "Database = ShoppingCartCA;" +
            "Integrated Security = true";*/
        
        private readonly User user;

        public CartController(User user)
        {
            this.user = user;
        }

        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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

        [HttpPost]
        public ActionResult PurchaseInformation(List<long> product)
        {
            string order = Guid.NewGuid().ToString();
            string orderid = order.Substring(1, 5);

            ViewData["orderid"] = "ORDER 000" + orderid;

            ViewData["userid"] = user.UserId;

            ViewData["productId"] = product;

            List<string> products = new List<string>();

            foreach (long id in product)
            {
                //products.Add("Product " + id);
                Debug.WriteLine(id);
            }

            ViewData["products"] = products;
            
            //List<string> activationCodes = new List<string>();

            /*
            foreach (int id in product)
            {
                    products.Add("Product" + id);
                    string code = Guid.NewGuid().ToString();
                    string activationcode = code.Substring(3, 12);

                    activationCodes.Add(activationcode);

                    
                    string sql = @"
                        INSERT INTO ORDER (OrderId, UserId, ProductId, ActivationCode)
                        VALUES(@orderid, @userid, @productid, @activationcode)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@orderid", orderid);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.AddWithValue("@productid", productid);
                        cmd.Parameters.AddWithValue("@activationcode", activationcode);

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }




            }*/

           //ViewData["productids"] = products;

           //ViewData["ActivationCodes"] = activationCodes;

            return View("PurchaseInfo", "Cart");
        }
    }
}
