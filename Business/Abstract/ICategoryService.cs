using Core.Utilities.Results;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetByIdWithProducts(int id);
        IResult RemoveFromCategoryProduct(int productId, int categoryId);
    }
}
