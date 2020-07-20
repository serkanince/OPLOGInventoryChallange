using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.InventoryItem
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        MSSQLDBContext _context;

        public InventoryItemRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.InventoryItem create(Domain.Entity.InventoryItem entity)
        {
            _context.InventoryItem.Add(entity);
            return entity;
        }


        public Domain.Entity.InventoryItem delete(Domain.Entity.InventoryItem entity)
        {
            _context.InventoryItem.Remove(entity);
            return entity;
        }


        public IQueryable<Domain.Entity.InventoryItem> GetAll(Expression<Func<Domain.Entity.InventoryItem, bool>> predicate)
        {
            return _context.InventoryItem.Where(predicate);
        }

        public IQueryable<Domain.Entity.InventoryItem> GetAll()
        {
            return _context.InventoryItem.AsQueryable();
        }

        public IQueryable<Domain.Entity.InventoryItem> getStockInventoryItem(Guid productId, int quantity)
        {
            //find closest container by product inventory item

            var inventoryItems = GetAll(x => x.ProductId == productId && x.Type == Domain.Enum.InventoryItemType.Stock)
                  .OrderBy(x => x.Container.Location.x)
                  .ThenBy(x => x.Container.Location.y)
                  .ThenBy(x => x.Container.Location.z);


            return inventoryItems.Take(quantity).AsQueryable();
        }

        public Domain.Entity.InventoryItem readById(Guid id)
        {
            return _context.InventoryItem.Where(x => x.ID == id).FirstOrDefault();
        }

        public Domain.Entity.InventoryItem update(Domain.Entity.InventoryItem entity)
        {
            _context.InventoryItem.Update(entity);
            return entity;
        }

    }
}
