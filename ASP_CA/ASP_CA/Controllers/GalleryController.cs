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
        public IActionResult Index()
        {
            List<Product> products = ProductData.GetAllProducts();
          
            ViewData["products"] = products;
            ViewData["header"] = "on";
            ViewData["Name"] = Request.Cookies["Name"];
            int quantity = CartData.QuantityCart();
            ViewData["quantity"] = quantity;
            if (ViewData["Name"] == null)
            {
                ViewData["greeting"] = "guest";
                return View();
            }
            else
            {
                ViewData["greeting"] = Request.Cookies["Name"];
                return View();
            }
        }

        [HttpPost]
       public IActionResult Click(string productId)
        {
                CartData.AddToCart(productId);
                Index();
                return View("Index");
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            List<Product> products = ProductData.GetAllProducts();

            List<Product> searchedproducts = new List<Product>();

            
            string lowersearch = (search.TrimEnd()).ToLower();

            foreach(var product in products)
            {
                if (product.ProductName.ToLower().Contains(lowersearch) | product.ProductDesc.ToLower().Contains(lowersearch) | product.ProductPrice.ToString().ToLower().Contains(lowersearch))
                {
                    searchedproducts.Add(product);
                }
            }
            ViewData["products"] = searchedproducts;
            ViewData["header"] = "on";
            ViewData["Name"] = Request.Cookies["Name"];
            int quantity = CartData.QuantityCart();
            ViewData["quantity"] = quantity;
            if (ViewData["Name"] == null)
            {
                ViewData["greeting"] = "guest";
                return View("Index");
            }
            else
            {
                ViewData["greeting"] = Request.Cookies["Name"];
                return View("Index");
            }
            
        }


        public IActionResult ClearCart()
        {
            
            CartData.ClearCart();
            ViewData["quantity"] = null;
            Index();
            return View("Index");
        }
    }
}
