﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CA.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index([FromServices] Sessions sessions)
        {
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            Session session = null;
            if (sessionId != null)
                sessions.map.TryGetValue(sessionId, out session);

            if (session == null && sessionId != null)
            {
                HttpContext.Response.Cookies.Delete("sessionId");
            }

            if (sessionId != null)
            {
                sessions.map.Remove(sessionId);
            }
            
            HttpContext.Response.Cookies.Delete("sessionId");
            return RedirectToAction("Index", "Gallery");
        }
    }
}
