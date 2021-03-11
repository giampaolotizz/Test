
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic Items",
            },
            new Category
            {
                Id = 2,
                Name = "Clothes",
                Description = "Dresses",
            },
            new Category
            {
                Id = 3,
                Name = "Grocery",
                Description = "Grocery Items",
            }
        );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Computer",
                Description = "Electronic Items",
                Price = 1000,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Smartphone",
                Description = "Electronic Items",
                Price = 500,
                CategoryId = 1
        },
            new Product
            {
                Id = 3,
                Name = "Camicia",
                Description = "Clothes items",
                Price = 25,
                CategoryId = 2
        }
        );
        }

    }
}

