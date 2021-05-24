using ShopAppDemo.Core.DataAccess;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
