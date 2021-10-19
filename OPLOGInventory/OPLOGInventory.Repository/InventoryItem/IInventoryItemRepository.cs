using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.InventoryItem
{
    public interface IInventoryItemRepository<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {
    }
}
