using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Data.DB;

namespace OPLOGInventory.Repository.InventoryItem
{
    public class InventoryItemRepository : RepositoryCrud<Data.Entity.InventoryItem>, IInventoryItemRepository
    {
        PostgreSqlDBContext _context;

        public InventoryItemRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

    }
}
