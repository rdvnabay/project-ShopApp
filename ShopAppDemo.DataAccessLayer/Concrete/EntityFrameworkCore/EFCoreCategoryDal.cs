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
    public class EFCoreCategoryDal:EfEntityRepositoryBase<Category,ShopAppContext>,ICategoryDal
    {
        public Category GetByIdWithProducts(int id)
        {
            using (var contex=new ShopAppContext())
            {
                return contex.Categories.Where(x => x.Id == id)
              .Include(x => x.ProductCategories)
              .ThenInclude(x => x.Product)
              .FirstOrDefault();
            }
        }

        public void RemoveFromCategoryProduct(int productId, int categoryId)
        {
            using (var contex = new ShopAppContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
                //contex.Database.ExecuteSqlCommand(cmd, productId, categoryId);
            }
        }
    }
}
