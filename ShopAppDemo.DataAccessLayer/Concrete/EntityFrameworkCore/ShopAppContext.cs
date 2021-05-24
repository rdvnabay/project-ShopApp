using Microsoft.EntityFrameworkCore;
using ShopAppDemo.Entities;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class ShopAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopAppDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(x => new { x.CategoryId, x.ProductId });
        }
    }
}
