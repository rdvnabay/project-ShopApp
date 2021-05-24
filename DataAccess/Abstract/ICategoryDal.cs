using ShopAppDemo.Core.DataAccess;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        public Category GetByIdWithProducts(int id);
        void RemoveFromCategoryProduct(int productId, int categoryId);
    }
}
