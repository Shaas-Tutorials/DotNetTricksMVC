using MVC_Filters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Controllers
{
    //[CustomAuthorizationFilter]
    //[CustomAuthenticationFilter]
    //[CustomResultFilter]
    //[CustomActionFilter]
    public class HomeController : Controller
    {
        //[CustomAuthorizationFilter]
        //[CustomAuthenticationFilter]
        //[CustomResultFilter]
        //[CustomActionFilter]
        public ActionResult Index()
        {
            int a = 0, b = 2;
            int c = b / a;
            Response.Write("Action Execution<br/>");
            return View();
        }
    }
}