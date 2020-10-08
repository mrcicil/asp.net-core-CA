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
        public IActionResult Index(Sessions sessions)
        {
            
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            sessions.map.Remove(sessionId);
            HttpContext.Response.Cookies.Delete("sessionId");
            return RedirectToAction("Index", "Login");
        }
    }
}
