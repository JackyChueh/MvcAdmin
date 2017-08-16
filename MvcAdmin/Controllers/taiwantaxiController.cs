using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Implement.EL;
using SystemCenter;

namespace MvcAdmin.Controllers
{
    public class taiwantaxiController : Controller
    {
        // version 1
        // GET: /taiwantaxi/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Main");
        }

        //
        // GET: /taiwantaxi/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /taiwantaxi/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Create()
        {
            System.Threading.Thread.Sleep(2500);
            //var model = new MyModel();

            if (Request.IsAjaxRequest())
            {
                AUTHORITY authority = new AuthorityImplement("SC").GetOne(269);
                return PartialView("Create", authority);
                //return PartialView("Create");
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /taiwantaxi/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(AUTHORITY collection)
        {//FormCollection
            try
            {
                // TODO: Add insert logic here

                return Json(new { success = true });
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /taiwantaxi/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /taiwantaxi/Edit/5

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
        // GET: /taiwantaxi/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /taiwantaxi/Delete/5

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
