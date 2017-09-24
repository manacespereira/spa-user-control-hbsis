using System;
using System.Linq;
using System.Linq.Expressions;

namespace HBSIS.SpaUserControl.Domain.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity GetById(string id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Get();
        void Dispose();
    }
}
