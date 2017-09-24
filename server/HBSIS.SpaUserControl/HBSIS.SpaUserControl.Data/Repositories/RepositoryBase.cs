using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HBSIS.SpaUserControl.Data.Context;
using HBSIS.SpaUserControl.Domain.Core;
using HBSIS.SpaUserControl.Domain.Interfaces;

namespace HBSIS.SpaUserControl.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected SpaContext Ctx = SpaContextSingleton.Instance;
        bool disposed = false;

        public void Add(TEntity obj)
        {
            Ctx.Set<TEntity>().Add(obj);
            Ctx.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Ctx.Entry(obj).State = EntityState.Modified;
            Ctx.SaveChanges();

        }

        public void Remove(TEntity obj)
        {
            Ctx.Set<TEntity>().Remove(obj);
            Ctx.SaveChanges();
        }

        public TEntity GetById(string id)
        {
            return Ctx.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes)
        {
            return filter == null ? includes.Aggregate(Ctx.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include)) : 
                includes.Aggregate(Ctx.Set<TEntity>().Where(filter), (current, include) => current.Include(include));
        }

        public IQueryable<TEntity> Get()
        {
            return Ctx.Set<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) { }

            disposed = true;
        }
    }
}
