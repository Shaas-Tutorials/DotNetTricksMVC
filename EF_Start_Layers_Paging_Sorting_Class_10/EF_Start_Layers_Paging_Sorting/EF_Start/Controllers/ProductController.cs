using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models;

namespace EF_Start.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repo_product;
        ICategoryRepository repo_cat;

        //public ProductController()
        //{
        //    repo_product = new ProductRepository();
        //    repo_cat = new CategoryRepository();
        //}

        public ProductController(IProductRepository _repo_product,ICategoryRepository _repo_cat)
        {
            repo_product = _repo_product;
            repo_cat = _repo_cat;
        }

        //public ActionResult Index()
        //{
        //    return View(repo_product.GetProducts());
        //}

        public ActionResult Index(int page = 1, string sort = "productid", string sortDir = "asc", string Search="")
        {
            return View(repo_product.GetProducts(page, sort.ToLower(), sortDir.ToLower(), Search));
        }

        public ActionResult Create()
        {
            ViewBag.CategoryList = repo_cat.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (repo_product.AddProduct(model))
                return RedirectToAction("index");
            else
                return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = repo_cat.GetCategories();
            return View("Create", repo_product.GetProduct(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (repo_product.UpdateProduct(model))
                return RedirectToAction("index");
            else
                return View();
        }

        public ActionResult Delete(int id)
        {
            repo_product.DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }
    }
}