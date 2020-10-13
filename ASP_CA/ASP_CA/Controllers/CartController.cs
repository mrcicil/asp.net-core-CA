using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using ASP_CA.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP_CA.Controllers
{
    public class CartController : Controller
    {

        public ActionResult Index()
        {
            ViewData["Name"] = Request.Cookies["Name"];  //logout display
            ViewData["AllTotalPrice"] = CartData.TotalPrice();
            ViewData["ViewCart"] = CartData.ViewCart();
            Response.Cookies.Delete("Fromgallery");
            Response.Cookies.Delete("searchedproducts");
            Response.Cookies.Append("Fromcart", "timer");  //enter this page when login
            ViewData["LoginDisplay"] = "on";
            return View();
        }
        [HttpPost]
        public IActionResult PlusOne([FromBody] JSONPro product)
        {
            CartData.PlusOneInCart(product.productId);

            return Json(new { status = "success" });
            //return RedirectToAction("Index", "Cart");  
        }
        [HttpPost]
        public IActionResult MinusOne([FromBody] JSONPro product)
        {
            CartData.MinusOneInCart(product.productId);
            return Json(new { status = "success" });
            //return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public IActionResult Remove(string productId)
        {
            CartData.RemoveInCart(productId);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult ClearCart()
        {
            CartData.ClearCart();
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult CheckOut()
        {
            int userId = Convert.ToInt32(Request.Cookies["userId"]);
            List<CartProduct> cartProducts = CartData.ViewCart();


            foreach(var cartProduct in cartProducts)
            {
                int quantity = cartProduct.ProductQuantity;
                for (int i = 0; i < quantity; i++)
                {
                    CartData.CheckOut(userId, cartProduct);
                }
            }
            CartData.ClearCart();
            return RedirectToAction("Index", "MyPurchases");
        }

    }
}
