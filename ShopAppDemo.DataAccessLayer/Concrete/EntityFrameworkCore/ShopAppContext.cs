using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class ShopAppContext:DbContext
    {
        public ShopAppContext(DbContextOptions<ShopAppContext> options)
            : base(options)
        {

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
