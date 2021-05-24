using ShopAppDemo.Core.DataAccessLayer.EntityFramework;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreOrderDal:EfEntityRepositoryBase<Order,ShopAppContext>,IOrderDal
    {
    }
}
