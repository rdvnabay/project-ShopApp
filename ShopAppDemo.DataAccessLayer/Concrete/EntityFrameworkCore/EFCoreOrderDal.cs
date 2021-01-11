using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
   public class EFCoreOrderDal:BaseRepository<Order>,IOrderDal
    {
        public EFCoreOrderDal(ShopAppContext context):base(context)
        {

        }
    }
}
