using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface IProductDal:IRepository<Product>
    {
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        int GetProductsByCategoryCount(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoriesID);
    }
}
