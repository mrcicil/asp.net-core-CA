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
        private readonly Sessions sessions;

        public LoginController(Sessions sessions)
        {
            this.sessions = sessions;
        }

        public IActionResult Index()
        {
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            Session session = null;
            if (sessionId != null)
                sessions.map.TryGetValue(sessionId, out session);

            if (session == null && sessionId != null) 
            {
                HttpContext.Response.Cookies.Delete("sessionId");
            }


            // to highlight "Login" as the selected menu-item
            ViewData["Is_Login"] = "menu_hilite";

            if (HttpContext.Request.Cookies["sessionId"] == null)
                return View();

            return RedirectToAction("Index", "Logout");
        }

        public IActionResult Authenticate(string username, string password)
        {
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            Session value = null;
            if (sessionId != null)
                sessions.map.TryGetValue(sessionId, out value);

            if (value == null && sessionId != null)
            {
                HttpContext.Response.Cookies.Delete("sessionId");
            }


            List<User> userlists = UserData.GetUserInfo();

            User user = new User();

            foreach(User u in userlists)
            {
                if (username == u.Username)
                {
                    user.Username = u.Username;
                    user.Password = u.Password;
                    user.UserId = u.UserId;
                }
            }

            if (username != user.Username && password != user.Password )
            {
                // to highlight "Login" as the selected menu-item
                ViewData["Is_Login"] = "menu_hilite";

                return View("Index");
            }
            else
            {
                // use a session to track this user
                Session session = new Session()
                {
                    SessionId = Guid.NewGuid().ToString(),
                    UserId = user.UserId,

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
