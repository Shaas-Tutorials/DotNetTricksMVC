using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;
using ViewModels;

namespace BAL
{
    public class ProductRepository : IProductRepository
    {
        DatabaseContext db = new DatabaseContext();
        int pageSize = 3;

        public IEnumerable<ProductViewModel> GetProducts()
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
            return modelList;
        }

        public ProductViewModel GetProduct(int ProductId)
        {
            //Product obj = db.Products.Where(p => p.ProductId == ProductId).FirstOrDefault();
            // Product obj = db.usp_getProduct(ProductId);

            Product obj = db.fn_getProduct(ProductId);

            ProductViewModel model = new ProductViewModel();
            if (obj != null)
            {
                model.ProductId = obj.ProductId;
                model.Name = obj.Name;
                model.UnitPrice = obj.UnitPrice;
                model.CategoryId = obj.CategoryId;
            }
            return model;
        }

        public bool UpdateProduct(ProductViewModel model)
        {
            try
            {
                Product obj = new Product();
                obj.ProductId = model.ProductId;
                obj.Name = model.Name;
                obj.UnitPrice = (int)model.UnitPrice;
                obj.CategoryId = model.CategoryId;

                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                Product data = db.Products.Where(p => p.ProductId == ProductId).FirstOrDefault();
                if (data != null)
                {
                    db.Products.Remove(data);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddProduct(ProductViewModel model)
        {
            try
            {
                Product obj = new Product();
                obj.Name = model.Name;
                obj.UnitPrice = (int)model.UnitPrice;
                obj.CategoryId = model.CategoryId;

                // db.Products.Add(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ProductPagedModel GetProducts(int page, string sort, string sortDir, string Search)
        {
            IQueryable<Product> data = db.Products.Select(p => p);
            
            if (!string.IsNullOrEmpty(Search))
            {
                data = data.Where(d => d.Name.Contains(Search));
            }

            switch (sort)
            {
                case "name" :
                    data = sortDir == "asc" ? data.OrderBy(d => d.Name) : data.OrderByDescending(d => d.Name);
                    break;
                case "unitprice":
                    data = sortDir == "asc" ? data.OrderBy(d => d.UnitPrice) : data.OrderByDescending(d => d.UnitPrice);
                    break;
                default:
                    data = sortDir == "asc" ? data.OrderBy(d => d.ProductId) : data.OrderByDescending(d => d.ProductId);
                    break;
            }

            int count = data.Count();
            data = data.Skip((page - 1) * pageSize).Take(pageSize);
            List<ProductViewModel> modelList = new List<ProductViewModel>();

            foreach (var item in data)
            {
                ProductViewModel obj = new ProductViewModel();
                obj.ProductId = item.ProductId;
                obj.Name = item.Name;
                obj.UnitPrice = item.UnitPrice;

                modelList.Add(obj);
            }
            ProductPagedModel model = new ProductPagedModel();
            model.TotalRecords = count;
            model.Products = modelList;
            model.PageSize = pageSize;

            return model;
        }
    }
}
