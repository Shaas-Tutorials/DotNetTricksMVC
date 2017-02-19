using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Models;

namespace BAL
{
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> GetProducts();

        ProductPagedModel GetProducts(int page, string sort, string sortDir, string Search);

        ProductViewModel GetProduct(int ProductId);
        bool AddProduct(ProductViewModel model);
        bool UpdateProduct(ProductViewModel model);
        bool DeleteProduct(int ProductId);        
    }
}
