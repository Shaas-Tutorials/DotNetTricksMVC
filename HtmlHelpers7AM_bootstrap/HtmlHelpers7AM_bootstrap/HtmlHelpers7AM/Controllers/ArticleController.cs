using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpers7AM.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetComments(int id)
        {
            List<string> comments = new List<string> { "Great Article", "Good Article", "Nice One" };

            return PartialView("_Comments", comments);
        }
    }
}