using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ViewModels;

namespace WebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class StoreApiController : ApiController
    {
        IProductRepository repo_product;
        IOrderRepository repo_order;

        public StoreApiController(IProductRepository _repo_product, IOrderRepository _repo_order)
        {
            repo_product = _repo_product;
            repo_order = _repo_order;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return repo_product.GetProducts();
        }

        public ProductViewModel GetProduct(int id)
        {
            return repo_product.GetProduct(id);
        }

        public int SaveCart(CartViewModel model)
        {
            return repo_order.SaveCart(model);
        }
    }
}
