using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CA.Data;
using ASP_CA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CA.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            Response.Cookies.Delete("userId");
            Response.Cookies.Delete("Name");
            CartData.ClearCart();
            return RedirectToAction("Index", "Login");
        }
    }
}
