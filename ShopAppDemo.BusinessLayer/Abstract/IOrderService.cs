using ShopAppDemo.Entities;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        void CreateOrder(Order entity);
    }
}
