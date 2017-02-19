using DAL.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Cart>(new CartMap());
            modelBuilder.Configurations.Add<CartItem>(new CartItemMap());
            modelBuilder.Configurations.Add<Category>(new CategoryMap());
            modelBuilder.Configurations.Add<Order>(new OrderMap());
            modelBuilder.Configurations.Add<OrderItem>(new OrderItemMap());
            modelBuilder.Configurations.Add<Product>(new ProductMap());
            modelBuilder.Configurations.Add<Role>(new RoleMap());
            modelBuilder.Configurations.Add<TransactionDetails>(new TransactionDetailsMap());
            modelBuilder.Configurations.Add<User>(new UserMap());
        }
    }
}
