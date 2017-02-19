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
        public StoreApiController(IProductRepository _repo_product)
        {
            repo_product = _repo_product;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return repo_product.GetProducts();
        }

        public ProductViewModel GetProduct(int id)
        {
            return repo_product.GetProduct(id);
        }
    }
}
