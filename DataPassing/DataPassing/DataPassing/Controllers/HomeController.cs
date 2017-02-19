using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataPassing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Name"] = "Shailendra";
            ViewBag.FullName = "Deepak Chauhan";

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(string Username, string FullName, string Address)
        {
            TempData["Username"] = Username;
            TempData["FullName"] = FullName;

            ViewData["Address"] = Address;
            ViewBag.FullName = FullName;

            Session["Address"] = Address;

            HttpCookie cookie = new HttpCookie("cookie", "This is cookie value");
            Response.Cookies.Add(cookie);

            return RedirectToAction("Message");
        }

        public ActionResult Message()
        {
            TempData.Keep("Username");
            HttpCookie cookie = Request.Cookies.Get("cookie");
            string value = cookie.Value;

            return View();
        }

        public ActionResult SaveData(int id, string name)
        {
            string n = Request.QueryString["name"];
            return View();
        }
    }
}