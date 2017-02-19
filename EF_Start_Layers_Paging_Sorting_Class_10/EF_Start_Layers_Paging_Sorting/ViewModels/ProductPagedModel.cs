using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels
{
    public class ProductPagedModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
    }
}
