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
    public class GalleryController : Controller
    {
        Sessions sessions;
        public GalleryController(Sessions sessions)
        {
            this.sessions = sessions;
        }
        public IActionResult Index(string error)
        {
            string sessionId = HttpContext.Request.Cookies["sessionId"];
            Session session = null;
            if (sessionId != null)
                sessions.map.TryGetValue(sessionId, out session);

            if (session == null && sessionId != null)
            {
                HttpContext.Response.Cookies.Delete("sessionId");
            }

            List<Product> products = ProductData.GetAllProducts();

            ViewData["products"] = products;

            ViewData["header"] = "on";
            ViewData["sessionId"] = sessionId;

            ViewData["error"] = error;
            
            return View();
        }

        public IActionResult Click()
        {

            ViewData["products"] = null;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
