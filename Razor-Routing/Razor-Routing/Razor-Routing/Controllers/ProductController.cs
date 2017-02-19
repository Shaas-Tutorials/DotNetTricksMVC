using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor_Routing.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id, int? catId) //model binders
        {
            return View();
        }
    }
}