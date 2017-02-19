using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class CartItemMap : EntityTypeConfiguration<CartItem>
    {
        public CartItemMap()
        {
            this.HasKey(c => c.CartItemId);

            this.HasRequired(c => c.Cart).WithMany(c => c.Items).HasForeignKey(c => c.CartId);
        }
    }
}
