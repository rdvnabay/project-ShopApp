using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Abstract
{
    public interface IOrderService:IRepositoryService<Order>
    {
        void CreateOrder(Order entity);
    }
}
