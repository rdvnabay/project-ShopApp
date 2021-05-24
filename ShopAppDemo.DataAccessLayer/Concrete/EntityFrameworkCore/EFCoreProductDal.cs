using Microsoft.EntityFrameworkCore;
using ShopAppDemo.Core.DataAccessLayer.EntityFramework;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreProductDal : EfEntityRepositoryBase<Product, ShopAppContext>, IProductDal
    {

        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopAppContext())
            {
                return context.Products
             .Where(x => x.Id == id)
             .Include(x => x.ProductCategories)
             .ThenInclude(x => x.Category)
             .FirstOrDefault();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new ShopAppContext())
            {
                return context.Products
                .Where(x => x.Id == id)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new ShopAppContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.ProductCategories.Any(x => x.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int GetProductsByCategoryCount(string category)
        {
            using (var context = new ShopAppContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.ProductCategories.Any(x => x.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public void Update(Product entity, int[] categoriesID)
        {
            using (var context = new ShopAppContext())
            {
                var product = context.Products
                .Include(x => x.ProductCategories)
                .Where(x => x.Id == entity.Id)
                .FirstOrDefault();


                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Image = entity.Image;
                    product.Price = entity.Price;
                    product.Description = entity.Description;

                    product.ProductCategories = categoriesID.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = entity.Id
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}


