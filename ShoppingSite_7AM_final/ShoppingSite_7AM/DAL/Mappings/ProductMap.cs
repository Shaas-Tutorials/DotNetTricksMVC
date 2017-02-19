using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //key
            this.HasKey(p => p.ProductId);

            this.Property(p => p.Name).HasMaxLength(200).IsRequired().IsUnicode(false);
            this.Property(p => p.ImageName).HasMaxLength(200).IsRequired().IsUnicode(false);
            this.Property(p => p.ImagePath).HasMaxLength(600).IsRequired().IsUnicode(false);

            //relation- 1:m
            this.HasRequired(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        }
    }
}
