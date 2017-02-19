using MVC_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Validation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            //if(string.IsNullOrEmpty(model.Username))
            //{
            //    ModelState.AddModelError("Username", "Please Enter Username");
            //}
            //if (string.IsNullOrEmpty(model.FullName))
            //{
            //    ModelState.AddModelError("FullName", "Please Enter FullName");
            //}

            if (ModelState.IsValid)
            {
                //TO DO:
                return RedirectToAction("Message");
            }
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}