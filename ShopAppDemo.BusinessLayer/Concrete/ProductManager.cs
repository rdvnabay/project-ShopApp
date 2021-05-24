using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public bool Create(Product entity)
        {
            if (Validate(entity))
            {
                _productDal.Add(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public IEnumerable<Product> GetAllFilter(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
        }

        public Product GetOneFilter(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.Get(filter);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return _productDal.GetProductsByCategory(category, page, pageSize);
        }

        public int GetProductsByCategoryCount(string category)
        {
            return _productDal.GetProductsByCategoryCount(category);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoriesID)
        {
            _productDal.Update(entity, categoriesID);
        }

        public string ErrorMessage { get; set; }
        public bool Validate(Product entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Ürün adı boş geçilemez";
                isValid = false;
            }
            return isValid;
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
