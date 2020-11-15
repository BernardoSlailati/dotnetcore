using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Models {
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}