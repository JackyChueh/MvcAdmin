using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Implement.EL;
using System.Web.Security;

namespace MvcAdmin.Controllers
{
    public class MainController : Controller
    {
        /// <summary>
        /// 系統入口
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            return View(new AuthorityImplement("SC").GetMenu(User.Identity.Name));
        }

        /// <summary>
        /// 版面功能選單
        /// </summary>
        /// <returns></returns>
        //[ChildActionOnly]
        //public ActionResult Menu()
        //{
        //    return PartialView("Menu", new AuthorityImplement("SC").GetMenu());
        //}

    }
}
