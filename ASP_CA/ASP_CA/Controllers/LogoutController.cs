using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CA.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index(Sessions sessions, UserIdCookies userIdCookies)
        {
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            sessions.map.Remove(sessionId);
            HttpContext.Response.Cookies.Delete("sessionId");
            string Userid = HttpContext.Request.Cookies["UserId"];
            userIdCookies.map.Remove(Convert.ToInt32(Userid));
            HttpContext.Response.Cookies.Delete("UserId");
            return RedirectToAction("Index", "Login");
        }
    }
}
