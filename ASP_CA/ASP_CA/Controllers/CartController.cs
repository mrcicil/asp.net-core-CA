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
    public class CartController : Controller
    {
        // GET: CartController
        public ActionResult Index()
        {
            List<Product> ShoppingCart = Data.ProductData.GetAllProducts(); 
            return View(ShoppingCart);
        }

        public ActionResult IncreaseOrDecreaseOne(string ProductID)
        {
            string connectionString = "data source=.; Database=ASP_CA; Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT ProductID
                                FROM Product Where ProductID="+ProductID;
                int sql = @"SELECT ProductPrice From Product Where ProductPrice=" + ProductPrice;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (Session["ShoppingCart"] == null)
                {
                    List<Product> ShoppingCart = new List<Product>();
                    ShoppingCart.Add(new Cart { Product = Product.find(ProductID), Quantity = 1 });
                    Session["ShoppingCart"] = ShoppingCart;
                }
                else
                {
                    List<Cart> ShoppingCart = (List<Cart>)Session["ShoppingCart"];
                    int index = isExist(ProductID);
                    if (index != -1)
                    {
                        ShoppingCart[index].Quantity++; 
                    }
                    else
                    {
                        ShoppingCart.Add(new Cart { Product = Product.find(ProductID), Quantity = 1 });
                    }
                    Session["ShoppingCart"] = ShoppingCart;
                }

                while (reader.Read())
                {
                    Product CartLine = new Product()
                    {
                        ProductID = (string)reader["ProductID"],
                        ProductPrice=(string)reader["ProductPrice"],
                    };
                    Product.Add(CartLine);
                }
                conn.Close();
            }
        }
        private int isExist(string ProductID)
        {
            List<Cart>ShoppingCart = (List<Cart>)Session["ShoppingCart"];
            for (int i = 0; i < ShoppingCart.Count; i++)
                if (ShoppingCart[i].Product.ProductID.Equals(ProductID))
                    return i;
            return -1;
        }

        // GET: CartController/Details/5a
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
     
    }
}
