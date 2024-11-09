using Laptopy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laptopy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
            {
                Id = 1,
                Name = "Dell XPS 13",
                Price = 999.99m,
                Discount = 0.1m,
                Description = "Dell XPS 13 with Intel i7, 16GB RAM, and 512GB SSD.",
                Brand = "Dell",
                Rate =4,
                Model = "XPS 13",
                CategoryID = 1,
            },
                 new Product
                 {
                     Id = 2,
                     Name = "MacBook Air M1",
                     Price = 1199.99m,
                     Discount = 0.15m,
                     Description = "Apple MacBook Air with M1 chip, 8GB RAM, and 256GB SSD.",
                     Brand = "Apple",
                     Rate = 5,
                     Model = "MacBook Air",
                     CategoryID = 1,
                 },
    new Product
    {
        Id = 3,
        Name = "HP Spectre x360",
        Price = 1099.99m,
        Discount = 0.2m,
        Description = "HP Spectre x360 with Intel i7, 16GB RAM, and 512GB SSD.",
        Brand = "HP",
        Rate = 3,
        Model = "Spectre x360",
        CategoryID = 1,
    }
 );

        }
    }
}