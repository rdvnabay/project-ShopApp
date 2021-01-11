using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public bool Create(Category entity)
        {
            _categoryDal.Create(entity);
            return true;
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public IEnumerable<Category> GetAllFilter(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAllFilter(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetByIdWithProducts(int id)
        {
            return _categoryDal.GetByIdWithProducts(id);
        }

        public Category GetOneFilter(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetOneFilter(filter);
        }

        public void RemoveFromCategoryProduct(int productId, int categoryId)
        {
            _categoryDal.RemoveFromCategoryProduct(productId, categoryId);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
