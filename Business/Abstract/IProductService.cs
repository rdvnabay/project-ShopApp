using ShopAppDemo.Entities;
using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Abstract
{
   public interface IProductService:IValidator<Product>
    {
        void Add(Product product);
        List<Product> GetAll();
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategory(string category, int page,int pageSize);
        int GetProductsByCategoryCount(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoriesID);
        Product GetById(int id);
        void Delete(Product entity);
    }
}
