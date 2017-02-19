using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
       public RoleMap()
       {
           this.HasKey(r => r.RoleId);

           this.Property(r => r.Name).IsUnicode(false).IsRequired().HasMaxLength(200); //
       }
    }
}
