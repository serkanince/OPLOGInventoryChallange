using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OPLOGInventory.Repository
{
    public interface IRepository<T, K>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T readById(K id);
        T create(T entity);
        T update(T entity);
        T delete(T entity);
    }
}
