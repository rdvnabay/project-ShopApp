using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopAppDemo.BusinessLayer.Concrete
{
    public class AppUserManager : IUserService
    {
        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllFilter(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetOneFilter(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
