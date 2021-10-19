using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OPLOGInventory.Repository
{
    public interface IRepositoryCrud<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// delete a entity.
        /// </summary>
        /// <param name="entity">Inserted entity</param>
        TEntity Remove(TEntity entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Filter an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}
