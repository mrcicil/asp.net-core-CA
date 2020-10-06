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
    public class GalleryController : Controller
    {
        

        public IActionResult Index()
        {
            ViewData["header"] = "on";
            ViewData["sessionId"] = HttpContext.Request.Cookies["sessionId"];
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
