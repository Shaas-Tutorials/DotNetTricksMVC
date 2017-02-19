using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
   public class CategoryMap : EntityTypeConfiguration<Category>
    {
       public CategoryMap()
       {
           this.HasKey(c => c.CategoryId);

           this.Property(c => c.Name).IsUnicode(false).IsRequired().HasMaxLength(100);
       }
    }
}
