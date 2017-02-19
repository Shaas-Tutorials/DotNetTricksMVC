using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IProductRepository
    {         
        bool AddProduct(ProductViewModel model);
        IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int id);
        bool DeleteProduct(int id);        
    }
}
