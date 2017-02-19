using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            this.HasKey(c => c.OrderItemId);

            this.HasRequired(c => c.Order).WithMany(o=>o.Items).HasForeignKey(c => c.OrderId);
        }
    }
}
