using ShopAppDemo.Core.DataAccess.EntityFramework;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreOrderDal:EfEntityRepositoryBase<Order,ShopAppContext>,IOrderDal
    {
    }
}
