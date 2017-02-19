using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            this.HasKey(c => c.CartId);

            //mapping
            this.HasRequired(c => c.User).WithMany(u=>u.Carts).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
        }
    }
}
