using Microsoft.EntityFrameworkCore;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreCategoryDal:BaseRepository<Category>,ICategoryDal
    {
        private readonly ShopAppContext _context;
        public EFCoreCategoryDal(ShopAppContext context):base(context)
        {
            _context = context;
        }

        public Category GetByIdWithProducts(int id)
        {
            return _context.Categories.Where(x => x.Id == id)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product)
                .FirstOrDefault();
        }

        public void RemoveFromCategoryProduct(int productId, int categoryId)
        {
            var cmd = @"delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
            _context.Database.ExecuteSqlCommand(cmd, productId, categoryId);
        }
    }
}
