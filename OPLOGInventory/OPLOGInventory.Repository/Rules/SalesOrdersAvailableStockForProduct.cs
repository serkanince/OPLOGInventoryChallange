using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrdersAvailableStockForProduct : IBusinessRule
    {
        private readonly PostgreSqlDBContext _context;
        private List<Domain.Entity.LineItem> _lineItems;

        private string _notAvailableProduct;

        public SalesOrdersAvailableStockForProduct(PostgreSqlDBContext context, List<Domain.Entity.LineItem> lineItems)
        {
            _lineItems = lineItems;
            _context = context;
        }


        public string Message => "A Sales Order requiring more stock than the available stock for that product in the warehouse cannot be created. Not Available Product SKU : " + _notAvailableProduct;

        public bool IsBroken()
        {
            var groupedLineItems = _lineItems.GroupBy(x => x.ProductId).Select(x => new { Key = x.Key, Total = x.Sum(y => y.Quantity) });

            foreach (var lineItem in groupedLineItems)
            {
                var totalAvailableStock = _context.InventoryItem.Where(x => x.Type == Domain.Enum.InventoryItemType.Stock && x.ProductId == lineItem.Key).Count();

                if (totalAvailableStock < lineItem.Total)
                {
                    _notAvailableProduct = _context.Product.Where(x => x.ID == lineItem.Key).FirstOrDefault().SKU;
                    return true;
                }
            }

            return false;
        }
    }
}
