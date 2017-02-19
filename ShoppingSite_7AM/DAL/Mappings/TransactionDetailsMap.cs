using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class TransactionDetailsMap : EntityTypeConfiguration<TransactionDetails>
    {
        public TransactionDetailsMap()
        {
            //primary key
            this.HasKey(t => t.TransactionDetailsId);

            //property
            this.Property(t => t.TransactionId).HasMaxLength(20).IsUnicode(false).IsRequired();
            this.Property(t => t.Status).HasMaxLength(20).IsUnicode(false).IsRequired();
            this.Property(t => t.PaymentType).HasMaxLength(20).IsUnicode(false);

            //relation
            this.HasRequired(t => t.User).WithMany().HasForeignKey(t => t.UserId);
            this.HasRequired(t => t.Cart).WithMany().HasForeignKey(t => t.CartId);
        }
    }
}
