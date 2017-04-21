using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Security;
using SystemCenter;
using Repository.Implement.EL;

namespace MvcAdmin.Controllers
{
    public class AuthorityController : Controller
    {
        //
        // GET: /Authority/UserLogin

        public ActionResult UserLogin()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            ViewBag.Lang = "zh-tw";
            ViewBag.Title = "登入頁面"+ User.Identity.Name;

            //var AutheticationManager = HttpContext.GetOwinContext().Authentication;
            //AuthenticationManager.SignOut();
            //var accountController = new AccountController();
            //accountController.SignOut();

            //_authnManager = HttpContext.GetOwinContext().Authentication;
            //AuthenticationManager.Authenticate.

            return View();
        }

        //
        // POST: /Authority/UserLogin
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin([Bind(Include="USR_ID,PWD")] USERS users)
        {
            string username = "";

            if (new UsersImplement("SC").CheckPassword(users.USR_ID, users.PWD))
            {
                username = users.USR_ID;
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                username,
                DateTime.Now,
                DateTime.Now.AddMinutes(30), // value of time out property
                false, // Value of IsPersistent property
                String.Empty,   //userData
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("Index", "Main");
        }

        //
        // GET: /Authority/UserLogout
        public ActionResult UserLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("UserLogin", "Authority");
        }


        //
        // GET: /Authority/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Authority/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Authority/Create

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
        // GET: /Authority/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Authority/Edit/5

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
        // GET: /Authority/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Authority/Delete/5

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
