using Core.Utilities.Results;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult CreateOrder(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<IEnumerable<Order>> GetAllFilter(Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        } 
    }
}
