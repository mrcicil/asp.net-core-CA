using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using ASP_CA.Data;

namespace ASP_CA.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Name"] = Request.Cookies["Name"];
            ViewData["AllTotalPrice"] = CartData.TotalPrice();
            ViewData["ViewCart"] = CartData.ViewCart();
            Response.Cookies.Delete("Fromgallery");
            Response.Cookies.Append("Fromcart", "timer");
            return View();
        }
    }
}
