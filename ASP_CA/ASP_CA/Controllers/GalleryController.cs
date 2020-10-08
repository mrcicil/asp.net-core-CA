using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_CA.Models;
using ASP_CA.Data;

namespace ASP_CA.Controllers
{
    public class GalleryController : Controller
    {
        private readonly Click click;

        public GalleryController(Click click)
        {
            this.click = click;
        }

        public IActionResult Index()
        {
            List<Product> products = ProductData.GetAllProducts();
          
            ViewData["products"] = products;
            ViewData["header"] = "on";
            ViewData["sessionId"] = HttpContext.Request.Cookies["sessionId"];
            if (ViewData["sessionId"] == null)
            {
                int quantity = CartData.QuantityTempCart();
                ViewData["quantity"] = quantity;
                return View();
            }
            else
            {
                int quantity = CartData.QuantityCart((HttpContext.Request.Cookies["UserId"]));
                ViewData["quantity"] = quantity;
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Click(string productId)
        {
            ViewData["sessionId"] = HttpContext.Request.Cookies["sessionId"];
            if (ViewData["sessionId"] == null)
            {
                CartData.AddToTempCart(Convert.ToInt32(productId));
                Index();
                return View("Index");
            }
            else
            {
                int userId = Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
                CartData.AddToCart(userId, Convert.ToInt32(productId));
                Index();
                return View("Index");
            } 
        }

        public IActionResult ClearCart()
        {
            
            CartData.ClearCart();
            CartData.ClearTempCart();
            ViewData["quantity"] = null;
            Index();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
