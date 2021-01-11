using ShopAppDemo.DataAccessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class EFCoreUserDal:BaseRepository<User>, IUserDal
    {
        public EFCoreUserDal(ShopAppContext context):base(context)
        {

        }
    }
}
