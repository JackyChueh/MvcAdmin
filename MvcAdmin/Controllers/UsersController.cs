using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Implement.EL;
using SystemCenter;
using Newtonsoft.Json;

namespace MvcAdmin.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(100);
            return View();
        }

        [HttpPost]
        public String Select()
        {
            //var json = new JavaScriptSerializer().Serialize(new UsersImplement("SC").GetAll());

            var data = new UsersImplement("SC").GetAllPagging(1, 10);
            //Pagging pg = new Pagging
            //{
            //    Data = data
            //};

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                //MissingMemberHandling = MissingMemberHandling.Ignore;
            };
            var json = JsonConvert.SerializeObject(data, settings);
            
            //var json = JsonConvert.SerializeObject(data);
            
            return json;
        }

        [HttpPost]
        public JsonResult Select2()
        {
            var data = new UsersImplement("SC").GetAll();   
            return Json(data);
        }

        //
        // GET: /Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

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
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

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
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

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
