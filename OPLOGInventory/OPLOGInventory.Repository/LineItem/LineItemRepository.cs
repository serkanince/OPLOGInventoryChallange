using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.LineItem
{
    public class LineItemRepository<TEntity> : RepositoryCrud<TEntity>, ILineItemRepository<TEntity> where TEntity : class
    {
        MSSQLDBContext _context;

        public LineItemRepository(MSSQLDBContext context) : base(context: context)
        {
            _context = context;
        }
    }
}
