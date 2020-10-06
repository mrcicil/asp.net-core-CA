using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_CA.Models;

namespace ASP_CA.Controllers
{
    public class LoginController : Controller
    {
        private readonly User user;
        private readonly Sessions sessions;

        public LoginController(User user, Sessions sessions)
        {
            this.user = user;
            this.sessions = sessions;
        }

        public IActionResult Index()
        {
            // to highlight "Login" as the selected menu-item
            ViewData["Is_Login"] = "menu_hilite";

            return View();
        }

        public IActionResult Authenticate(string username, string password)
        {
            
            if (username != user.Username && password != user.Password )
            {
                // to highlight "Login" as the selected menu-item
                ViewData["Is_Login"] = "menu_hilite";

                ViewData["errMsg"] = "No such user or incorrect password.";
                return View("Index");
            }
            else
            {
                // use a session to track this user
                Session session = new Session()
                {
                    SessionId = Guid.NewGuid().ToString(),
                    UserId = user.UserId,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                };
                sessions.map[session.SessionId] = session;

                Response.Cookies.Append("sessionId", session.SessionId);
                return RedirectToAction("Index", "Gallery");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
