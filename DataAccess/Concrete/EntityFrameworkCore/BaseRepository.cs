using Microsoft.EntityFrameworkCore;
using ShopAppDemo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopAppDemo.DataAccessLayer.Concrete.EntityFrameworkCore
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class

    {
        private DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();

        }

        public virtual IEnumerable<TEntity> GetAllFilter(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();

        }

        public virtual TEntity GetById(int id)
        {
                return _context.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetOneFilter(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().Where(filter).SingleOrDefault();

        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
