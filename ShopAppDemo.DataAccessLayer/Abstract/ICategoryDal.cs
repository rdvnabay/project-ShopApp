using ShopAppDemo.Core.DataAccessLayer;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        public Category GetByIdWithProducts(int id);
        void RemoveFromCategoryProduct(int productId, int categoryId);
    }
}
