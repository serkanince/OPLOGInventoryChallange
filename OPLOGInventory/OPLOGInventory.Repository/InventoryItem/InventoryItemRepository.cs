using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.InventoryItem
{
    public class InventoryItemRepository : RepositoryCrud<Domain.Entity.InventoryItem>, IInventoryItemRepository
    {
        PostgreSqlDBContext _context;

        public InventoryItemRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

    }
}
