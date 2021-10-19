using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Repository.Location;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Repository.Product
{
    public class ProductRepository<TEntity> : RepositoryCrud<TEntity>, IProductRepository<TEntity> where TEntity : class
    {
        MSSQLDBContext _context;

        public ProductRepository(MSSQLDBContext context) : base(context: context)
        {
            _context = context;
        }



        public Domain.Entity.Product readBySKU(string sku)
        {
            return _context.Product.FirstOrDefault(x => x.SKU == sku);
        }
    }
}
