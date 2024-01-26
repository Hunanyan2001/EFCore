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
                        .HasForeignKey(p => p.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Manufacturer)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p=>p.ManufacturerId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                        .HasKey(p=>p.Id);


            modelBuilder.Entity<ProductSupplier>()
                        .HasOne(ps => ps.Product)
                        .WithMany(p => p.ProductSupplier)
                        .HasForeignKey(ps => ps.ProductId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                        .HasOne(ps => ps.Supplier)
                        .WithMany(s => s.ProductSupplier)
                        .HasForeignKey(ps => ps.SupplierId)
                        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I6JDFV5;Database=Library;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
