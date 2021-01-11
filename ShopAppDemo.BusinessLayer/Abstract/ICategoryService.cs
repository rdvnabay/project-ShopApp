using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Abstract
{
   public interface ICategoryService:IRepositoryService<Category>
    {
        public Category GetByIdWithProducts(int id);
        void RemoveFromCategoryProduct(int productId, int categoryId);
    }
}
