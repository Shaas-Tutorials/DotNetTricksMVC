using HtmlHelpers7AM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpers7AM.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //model binders
        //public ActionResult Index(string[] Name, string FullName, string Password, string Address)
        //{
        //    return View();
        //}

        public ActionResult Index(UserViewModel model, string Command)
        {
            if (Command=="Save")
            {

            }
            else if (Command == "Cancel")
            {

            }
            return View();
        }

        public ActionResult StronglyTyped()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult StronglyTyped(UserViewModel model)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult StronglyTyped(string Username, string FullName, string Password, string Address)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult StronglyTyped(FormCollection form)
        {
            string Username = form["Username"];
            string FullName = form["FullName"];
            string Password = form["Password"];
            string Address = form["Address"];

            return View();
        }

        public ActionResult Templated()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Templated(UserViewModel model)
        {
            return View();
        }
    }
}