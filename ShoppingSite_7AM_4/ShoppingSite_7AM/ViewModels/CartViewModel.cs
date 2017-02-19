using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public int UserId { get; set; }
        public decimal PayableAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<CartItemViewModel> Items { get; set; }
    }
}
