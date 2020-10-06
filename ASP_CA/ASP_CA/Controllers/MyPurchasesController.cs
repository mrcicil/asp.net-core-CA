using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_CA.Models;

namespace ASP_CA.Controllers
{
    public class MyPurchasesController : Controller
    {
        // GET: MyPurchasesController
        public ActionResult Index()
        {
            return View();
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
