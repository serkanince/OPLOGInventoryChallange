using Microsoft.EntityFrameworkCore;
using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OPLOGInventory.Repository
{
    public class RepositoryCrud<TEntity> : RepositoryBase, IRepositoryCrud<TEntity> where TEntity : class
    {
        MSSQLDBContext _context;
        private DbSet<TEntity> _table => _context.Set<TEntity>();

        public RepositoryCrud(MSSQLDBContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _table.AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _table.Where(predicate).AsQueryable();
        }

        public TEntity Insert(TEntity entity)
        {
            return _table.Add(entity).Entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return (await _table.AddAsync(entity)).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return (_table.Update(entity)).Entity;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _table.Where(predicate);
            return query;
        }

        public TEntity Remove(TEntity entity)
        {
            return _table.Remove(entity).Entity;
        }
    }
}
