using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cart
    {
        public Cart()
        {
            Items = new HashSet<CartItem>();
        }
        public int CartId { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public int UserId { get; set; }
        public decimal PayableAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
        public virtual User User { get; set; }
    }
}
