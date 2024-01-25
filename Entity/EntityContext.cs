using ConsoleApp2.Models;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Entity
{
    public class EntityContext : DbContext
    {
        public EntityContext() { }
        public EntityContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        // if forign key not set default set product id forign key
                        .HasForeignKey(p => p.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>()
            //            .HasOne(p => p.Manufacturer)
            //            .WithMany(c => c.Products)
            //            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ProductSupplier>()
            //            .HasKey(m => new { m.SupplierId, m.ProductId });

            //modelBuilder.Entity<ProductSupplier>()
            //            .HasOne(ps => ps.Product)
            //            .WithMany(p => p.ProductSupplier)
            //            .HasForeignKey(ps => ps.ProductId)
            //            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ProductSupplier>()
            //            .HasOne(ps => ps.Supplier)
            //            .WithMany(s => s.ProductSupplier)
            //            .HasForeignKey(ps => ps.SupplierId)
            //            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
