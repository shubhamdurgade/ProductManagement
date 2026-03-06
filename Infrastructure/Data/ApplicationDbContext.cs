using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High-end gaming laptop"},
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone"},
                new Product { Id = 3 , Name = "Wireless HeadPhone", Description = "Noise cancelation"}
            );
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
