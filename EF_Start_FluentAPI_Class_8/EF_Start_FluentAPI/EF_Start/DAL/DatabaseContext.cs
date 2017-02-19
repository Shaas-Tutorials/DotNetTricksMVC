using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EF_Start.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public Product usp_getProduct(int ProductId)
        {
           return this.Database.SqlQuery<Product>("Exec usp_getProduct @ProductId", new SqlParameter("ProductId", ProductId)).FirstOrDefault();
        }

        public Product fn_getProduct(int ProductId)
        {
            return this.Database.SqlQuery<Product>("Select * from fn_getProduct(@ProductId)", new SqlParameter("ProductId", ProductId)).FirstOrDefault();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Product Mappings
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId).ToTable("Product");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            //1:m
            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany(c=>c.Products).HasForeignKey(p => p.CategoryId);
            
            //category mappings
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId).ToTable("Category");
            modelBuilder.Entity<Category>().Property(c => c.Name).IsUnicode(false).HasMaxLength(250);
        }
    }
}