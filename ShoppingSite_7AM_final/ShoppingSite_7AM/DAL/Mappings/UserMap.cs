using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //primary key
            this.HasKey(u => u.UserId);

            //properties
            this.Property(u => u.Name).IsUnicode(false).HasMaxLength(50).IsRequired();
            this.Property(u => u.Password).IsUnicode(false).HasMaxLength(50).IsRequired();
            this.Property(u => u.Address).IsUnicode(false).HasMaxLength(500);
            this.Property(u => u.ContactNo).IsUnicode(false).HasMaxLength(20);

            //relation- m:m
            this.HasMany(u => u.Roles).WithMany(r => r.Users).Map(m =>
            {
                //composite primary key
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
                //table name
                m.ToTable("UserRoles");
            });
        }
    }
}
