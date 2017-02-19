using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
        public string ContactNo { get; set; }

        public int CartId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }

        public decimal GrandTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal PayableAmount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
