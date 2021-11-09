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
    public class RepositoryCrud<T> : RepositoryBase,IRepositoryCrud<T> where T : class
    {
        private readonly PostgreSqlDBContext _context;
        protected readonly DbSet<T> _table;


        public RepositoryCrud(PostgreSqlDBContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).AsQueryable();
        }

        public T Insert(T entity)
        {
            return _table.Add(entity).Entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            return (await _table.AddAsync(entity)).Entity;
        }

        public T Update(T entity)
        {
            return (_table.Update(entity)).Entity;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _table.Where(predicate);
            return query;
        }

        public T Remove(T entity)
        {
            return _table.Remove(entity).Entity;
        }
    }
}
