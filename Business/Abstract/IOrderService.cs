using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        void CreateOrder(Order entity);
        IEnumerable<Order> GetAllFilter(Expression<Func<Order, bool>> filter = null);
    }
}
