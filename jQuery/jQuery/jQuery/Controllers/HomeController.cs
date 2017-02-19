using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQuery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Selectors()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(FormCollection form)
        {
            int count = Convert.ToInt32(form["ddlCustomer"]);
            List<string> data = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                string name = "txt" + i.ToString();
                string value = form[name];

                data.Add(value);
            }
            //TO DO:

            return View();
        }
    }
}