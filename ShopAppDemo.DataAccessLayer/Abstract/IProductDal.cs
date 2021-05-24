using ShopAppDemo.Core.DataAccessLayer;
using ShopAppDemo.Entities;
using System.Collections.Generic;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        int GetProductsByCategoryCount(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoriesID);
    }
}
