using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopAppDemo.Core.DataAccessLayer.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TContext:DbContext,new()
        where TEntity:class,new()
    {
        public void Add(TEntity entity)
        {
            using (var context= new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(expression);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            using (var context = new TContext())
            {
                return expression == null
                    ? context.Set<TEntity>().Where(expression).ToList()
                    : context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
