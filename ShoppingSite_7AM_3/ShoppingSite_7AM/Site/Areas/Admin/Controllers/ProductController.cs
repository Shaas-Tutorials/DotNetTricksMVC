using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using ViewModels;


namespace Site.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IProductRepository repo_product;
        ICategoryRepository repo_category;
        public ProductController(IProductRepository _repo_product, ICategoryRepository _repo_category)
        {
            repo_product = _repo_product;
            repo_category = _repo_category;
        }

        void BindCategory()
        {
            ViewBag.CategoryList = repo_category.GetCategories();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(repo_product.GetProducts());
        }

        public ActionResult Create()
        {
            BindCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                var fileName = Path.GetFileName(model.file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                model.file.SaveAs(path);

                model.ImageName = fileName;
                model.ImagePath = "/Uploads/" + fileName;

                repo_product.AddProduct(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            BindCategory();
            return View();
        }

        public ActionResult Delete(int id)
        {
            repo_product.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}