using Core.Utilities.Results;
using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        IResult CreateOrder(Order entity);
        IDataResult<IEnumerable<Order>> GetAllFilter(Expression<Func<Order, bool>> filter = null);
    }
}
