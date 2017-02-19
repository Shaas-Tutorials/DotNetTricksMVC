using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Start7AM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public RedirectToRouteResult Index()
        {
            //response.redirect
            return RedirectToAction("Index", "Account");

            //Server.Transfer
            //return View("~/views/account/index.cshtml");
            //return View("~/views/shared/index.cshtml");
           // return View("MyIndex");

            //return View();
        }

        public ActionResult MyIndex(int? id)
        {
            if (id == null)
                return View();
            else if (id == 2)
            {
                var obj=new {id=1,name="Shailendra"};
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
                return RedirectToAction("Index");
        }

        [NonAction]
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}