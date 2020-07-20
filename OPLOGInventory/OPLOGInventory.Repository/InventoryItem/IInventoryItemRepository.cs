using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.InventoryItem
{
    public interface IInventoryItemRepository : IRepository<Domain.Entity.InventoryItem, Guid>
    {
        IQueryable<Domain.Entity.InventoryItem> getStockInventoryItem(Guid productId, int quantity);
    }
}
