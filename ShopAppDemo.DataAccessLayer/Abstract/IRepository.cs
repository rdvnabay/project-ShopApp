﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopAppDemo.DataAccessLayer.Abstract
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity GetById(int id);
        TEntity GetOneFilter(Expression<Func<TEntity, bool>> filter=null);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllFilter(Expression<Func<TEntity, bool>> filter=null);
    }
}
