using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
namespace BAL
{
    public class ProductRepository : IProductRepository
    {
        DatabaseContext db = new DatabaseContext();
        
        public bool AddProduct(ProductViewModel model)
        {
            try
            {
                Product product = new Product();

                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.ImageName = model.ImageName;
                product.ImagePath = model.ImagePath;
                product.CategoryId = model.CategoryId;
                product.CreatedDate = DateTime.Now;
                product.Description = model.Description;

                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            List<Product> data = db.Products.ToList();
            List<ProductViewModel> model = new List<ProductViewModel>();

            foreach (var item in data)
            {
                ProductViewModel obj = new ProductViewModel();
                obj.ProductId = item.ProductId;
                obj.Name = item.Name;
                obj.ImageName = item.ImageName;
                obj.ImagePath = item.ImagePath;
                obj.UnitPrice = item.UnitPrice;
                obj.Description = item.Description;

                model.Add(obj);
            }
            return model;
        }

        public ProductViewModel GetProduct(int id)
        {
            Product item = db.Products.Find(id);
            if (item != null)
            {
                ProductViewModel obj = new ProductViewModel();
                obj.ProductId = item.ProductId;
                obj.Name = item.Name;
                obj.ImageName = item.ImageName;
                obj.ImagePath = item.ImagePath;
                obj.UnitPrice = item.UnitPrice;
                obj.Description = item.Description;

                return obj;
            }
            else
            {
                return null;
            }
        }
               
        public bool DeleteProduct(int id)
        {
            try
            {
                Product obj = db.Products.Find(id);
                db.Products.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
