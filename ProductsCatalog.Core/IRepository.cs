using System;
using System.Linq;

namespace ProductsCatalog.Core
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        IQueryable<TEntity> All();

        TEntity GetById(long id);

        int SaveChanges();
    }
}
