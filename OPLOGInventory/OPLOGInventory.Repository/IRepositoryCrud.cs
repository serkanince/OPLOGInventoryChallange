using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OPLOGInventory.Repository
{
    public interface IRepositoryCrud<T> where T : class
    {
        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        T Insert(T entity);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// delete a entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        T Remove(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        T Update(T entity);

        /// <summary>
        /// Filter an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
