using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(o => o.OrderId);

            //relation
            //1:m
            this.HasRequired(o => o.User).WithMany().HasForeignKey(o => o.UserId).WillCascadeOnDelete(false);

            this.HasRequired(o => o.Cart).WithMany().HasForeignKey(o => o.CartId);
        }
    }
}
