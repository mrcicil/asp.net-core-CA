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
        private readonly UserIdCookies userIdCookies;

        public LoginController(Sessions sessions, UserIdCookies userIdCookies)
        {
            this.sessions = sessions;
            this.userIdCookies = userIdCookies;
        }

        public IActionResult Index()
        {
            // to highlight "Login" as the selected menu-item
            ViewData["Is_Login"] = "menu_hilite";
            CartData.ClearTempCart();

            if (HttpContext.Request.Cookies["sessionId"] == null)
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
                    user.Password = u.Password;
                    user.UserId = u.UserId;
                }
            }
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
                userIdCookies.map[session.UserId] = session;

                Response.Cookies.Append("sessionId", session.SessionId);
                Response.Cookies.Append("UserId", Convert.ToString(session.UserId));
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
