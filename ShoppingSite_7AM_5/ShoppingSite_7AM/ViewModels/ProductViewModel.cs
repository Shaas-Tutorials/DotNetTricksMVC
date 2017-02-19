using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase file { get; set; }

        public string Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
