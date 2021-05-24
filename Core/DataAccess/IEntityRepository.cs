using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T,bool>> expression=null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
