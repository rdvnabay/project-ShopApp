using ShopAppDemo.Core.DataAccessLayer;
using ShopAppDemo.Entities;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
