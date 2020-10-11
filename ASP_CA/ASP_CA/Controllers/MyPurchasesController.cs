using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;
using ASP_CA.Data;

namespace ASP_CA.Controllers
{
    public class MyPurchasesController : Controller
    {
        
        public ActionResult Index()
        {
            ViewData["Name"] = Request.Cookies["Name"];
            string userId = Request.Cookies["userId"];
            List<MyPurchase> myPurchases = MyPurchasesData.GetAllData(userId);
            List<SummariseMyPurchase> summariseMyPurchases = MyPurchasesData.GetSummaryData(userId);
            ViewData["MyPurchases"] = myPurchases;
            Response.Cookies.Delete("Fromcart");
            ViewData["SummariseMyPurchases"] = summariseMyPurchases;
            return View();
        }

        
    }
}
