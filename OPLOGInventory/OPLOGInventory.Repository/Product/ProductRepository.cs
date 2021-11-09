using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Data.DB;
using OPLOGInventory.Repository.Location;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Repository.Product
{
    public class ProductRepository : RepositoryCrud<Data.Entity.Product>, IProductRepository
    {
        PostgreSqlDBContext _context;

        public ProductRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }



        public Data.Entity.Product readBySKU(string sku)
        {
            return _context.Product.FirstOrDefault(x => x.SKU == sku);
        }
    }
}
