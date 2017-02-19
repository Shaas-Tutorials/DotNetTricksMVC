using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor_Routing.Controllers
{
    [RoutePrefix("employee")]
    public class EmployeeController : Controller
    {
        [Route("Details/{id}/{catId}")]
        public ActionResult Index(int? id, int? catId)
        {
            return View();
        }

        [Route("~/show-details/{id}")]
        public ActionResult MyIndex(int? id)
        {
            return View();
        }

        public ActionResult ShowData(int id)
        {
            return View();
        }
    }
}