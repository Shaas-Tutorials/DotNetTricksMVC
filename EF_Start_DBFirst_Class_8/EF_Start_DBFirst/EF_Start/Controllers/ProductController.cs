using EF_Start.DAL;
using EF_Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_Start.Controllers
{
    public class ProductController : Controller
    {
        EF_Start7AMEntities db = new EF_Start7AMEntities();

        private IEnumerable<CategoryViewModel> BindCategory()
        {
            //List<Category> data = db.Categories.ToList(); 
            //or
            List<Category> data = db.Categories.Select(c => c).ToList();
            List<CategoryViewModel> modelList = new List<CategoryViewModel>();

            foreach (var item in data)
            {
                CategoryViewModel obj = new CategoryViewModel();
                obj.CategoryId = item.CategoryId;
                obj.Name = item.Name;

                modelList.Add(obj);
            }
            return modelList;
        }

        public ActionResult Index()
        {
            List<ProductViewModel> modelList = new List<ProductViewModel>();
            List<Product> data = db.Products.Select(p => p).ToList(); //immediate execution

            foreach (var item in data)
            {
                ProductViewModel obj = new ProductViewModel();
                obj.ProductId = item.ProductId;
                obj.Name = item.Name;
                obj.UnitPrice = item.UnitPrice;

                modelList.Add(obj);
            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryList = BindCategory();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            Product obj = new Product();
            obj.Name = model.Name;
            obj.UnitPrice =(int) model.UnitPrice;
            obj.CategoryId = model.CategoryId;

           // db.Products.Add(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = BindCategory();
            //Product obj = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            // Product obj = db.usp_getProduct(id).FirstOrDefault();

            Product obj = db.fn_getProduct(id).FirstOrDefault();

            ProductViewModel model= new ProductViewModel();
            if (obj != null)
            {
                model.ProductId = obj.ProductId;
                model.Name = obj.Name;
                model.UnitPrice = obj.UnitPrice;
                model.CategoryId = obj.CategoryId;
            }
            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            Product obj = new Product();
            obj.ProductId = model.ProductId;
            obj.Name = model.Name;
            obj.UnitPrice = (int)model.UnitPrice;
            obj.CategoryId = model.CategoryId;

            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Product data = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (data != null)
            {
                db.Products.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}