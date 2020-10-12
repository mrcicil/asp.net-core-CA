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
        protected static readonly string connectionString = "data source=DESKTOP-BU3GJLT; Database=ASP_CA; Integrated Security=true";
        // GET: MyPurchasesController
        public ActionResult Index()
        {
            List<MyPurchases> allPurchases = MyPurchasesData.GetAllMyPurchases();
            string[] images =
            {
                "1.png",
                "2.png",
                "3.png",
                "4.png",
                "5.png",
                "6.png"
            };
            ViewData["images"] = images;
            return View(allPurchases);
        }

        // GET: MyPurchasesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyPurchasesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPurchasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPurchasesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPurchasesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPurchasesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyPurchasesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
