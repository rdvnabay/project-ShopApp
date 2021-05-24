using Core.Utilities.Results;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> GetByIdWithProducts(int id)
        {
            var data= _categoryDal.GetByIdWithProducts(id);
            return new SuccessDataResult<Category>(data);
        }

        public IResult RemoveFromCategoryProduct(int productId, int categoryId)
        {
            _categoryDal.RemoveFromCategoryProduct(productId, categoryId);
            return new SuccessResult();
        }
    }
}
