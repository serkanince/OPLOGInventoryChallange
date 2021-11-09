using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Repository.Container;

namespace OPLOGInventory.Repository.Dimension
{
    public class DimensionRepository<TEntity> : RepositoryCrud<TEntity>, IDimensionRepository<TEntity> where TEntity : class
    {
        PostgreSqlDBContext _context;

        public DimensionRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

        public Domain.Entity.Container ReadByLabel(string label) 
        {
            throw new NotImplementedException();
        }
    }
}
