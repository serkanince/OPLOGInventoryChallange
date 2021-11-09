using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class ProductsConnotSameSKU : IBusinessRule
    {
        private readonly PostgreSqlDBContext _context;
        private readonly string _newSKU;

        public ProductsConnotSameSKU(PostgreSqlDBContext context, string sku)
        {
            _newSKU = sku;
            _context = context;
        }

        public string Message => "A product with the same SKU defined in the system already cannot be created.";

        public bool IsBroken()
        {
            return _context.Product.Where(x => x.SKU.Contains(_newSKU)).Any();
        }
    }
}
