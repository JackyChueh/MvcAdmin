using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdmin.Controllers
{
    public class FunctionsController : Controller
    {
        //
        // GET: /Functions/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Functions/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Functions/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Functions/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Functions/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Functions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Functions/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Functions/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
