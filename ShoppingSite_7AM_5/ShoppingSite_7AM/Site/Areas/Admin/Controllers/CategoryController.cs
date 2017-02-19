using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Site.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository repo_cat;
        public CategoryController(ICategoryRepository _repo_cat)
        {
            repo_cat = _repo_cat;
        }

        public ActionResult Index()
        {
            return View(repo_cat.GetCategories());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (repo_cat.AddCategory(model))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}