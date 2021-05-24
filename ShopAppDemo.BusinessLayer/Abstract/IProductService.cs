﻿using ShopAppDemo.Entities;
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
    }
}
