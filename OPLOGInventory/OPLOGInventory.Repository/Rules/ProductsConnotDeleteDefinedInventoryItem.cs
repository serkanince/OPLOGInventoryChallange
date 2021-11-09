using OPLOGInventory.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class ProductsConnotDeleteDefinedInventoryItem : IBusinessRule
    {
        private readonly PostgreSqlDBContext _context;
        private readonly Guid _productId;

        public ProductsConnotDeleteDefinedInventoryItem(PostgreSqlDBContext context, Guid productId)
        {
            _context = context;
            _productId = productId;
        }

        public string Message => "A product with an Inventory Item defined in the system cannot be deleted.";

        public bool IsBroken()
        {
            return _context.InventoryItem.Where(x => x.ProductId == _productId).Any();
        }
    }
}
