using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels.Models;
namespace PL_UnitTest.FakeObjects
{
    public class FakeProductRepository : IProductRepository
    {
        List<ProductViewModel> db;
        public FakeProductRepository(List<ProductViewModel> _db)
        {
            db = _db;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return db;
        }

        public ProductViewModel GetProduct(int ProductId)
        {
            return db.Find(d => d.ProductId == ProductId);
        }

        public bool AddProduct(ProductViewModel model)
        {
            db.Add(model);
            return true;
        }

        public bool UpdateProduct(ProductViewModel model)
        {
            for (int i = 0; i < db.Count; i++)
            {
                if (db[i].ProductId == model.ProductId)
                {
                    db[i].Name = model.Name;
                    db[i].UnitPrice = model.UnitPrice;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProduct(int ProductId)
        {
            ProductViewModel model = db.Find(p => p.ProductId == ProductId);
            if (model != null)
            {
                db.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
