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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            // to highlight "Login" as the selected menu-item
            ViewData["Is_Login"] = "menu_hilite";
            Response.Cookies.Delete("searchedproducts");

            if (Request.Cookies["Name"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Logout");
            }
        }
        public IActionResult FirstPage()
        {
            // to highlight "Login" as the selected menu-item
            ViewData["Is_Login"] = "menu_hilite";
            CartData.ClearCart();
            Response.Cookies.Delete("searchedproducts");
            Response.Cookies.Delete("Fromcart");
            ViewData["LoginDisplay"] = "off";
            if (Request.Cookies["Name"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Logout");
            }
        }
        public IActionResult Authenticate(string username, string password)
        {
            List<User> userlists = UserData.GetUserInfo();
            User user = new User();
            
            foreach (User u in userlists)
            {
                if (username == u.Username)
                {
                    user.Username = u.Username;
                    user.Name = u.Name;
                    user.Password = u.Password;
                    user.UserId = u.UserId;
                }
            }
            if (username != user.Username || password != user.Password )
            {
                // to highlight "Login" as the selected menu-item
                ViewData["Is_Login"] = "menu_hilite";

                ViewData["errMsg"] = "No such user or incorrect password.";
                return View("Index");
            }
            else
            {
                string userIdCookie = user.UserId.ToString();
                string nameCookie = user.Name;
                Response.Cookies.Append("userId", userIdCookie);
                Response.Cookies.Append("Name", nameCookie);

                if (Request.Cookies["Fromcart"] == null)
                {
                    return RedirectToAction("Index", "Gallery");
                }
                else
                {
                    return RedirectToAction("Index", "Cart");
                }
                
            }
        }
    }
}
