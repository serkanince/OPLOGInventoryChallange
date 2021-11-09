using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.LineItem
{
    public class LineItemRepository : RepositoryCrud<Domain.Entity.LineItem>, ILineItemRepository
    {
        PostgreSqlDBContext _context;

        public LineItemRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }
    }
}
