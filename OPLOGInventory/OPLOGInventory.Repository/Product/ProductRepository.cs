using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Repository.Product
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        MSSQLDBContext _context;

        public ProductRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.Product create(Domain.Entity.Product entity)
        {
            CheckRule(new ProductsConnotSameSKU(_context, entity.SKU));
            CheckRule(new ProductsConnotSameBarcode(_context, entity.Barcodes.Select(x => x.Label).ToList()));

            _context.Product.Add(entity);

            return entity;
        }

        public Domain.Entity.Product delete(Domain.Entity.Product entity)
        {
            CheckRule(new ProductsConnotDeleteDefinedInventoryItem(_context, entity.ID));
            CheckRule(new ProductsConnotDeleteDefinedSalesOrder(_context, entity.ID));

            _context.Product.Remove(entity);

            return entity;
        }

        public IQueryable<Domain.Entity.Product> GetAll(Expression<Func<Domain.Entity.Product, bool>> predicate)
        {
            return _context.Product.Where(predicate).AsQueryable();
        }

        public IQueryable<Domain.Entity.Product> GetAll()
        {
            return _context.Product.AsQueryable();
        }

        public Domain.Entity.Product readById(Guid id)
        {
            return _context.Product.FirstOrDefault(x => x.ID == id);
        }

        public Domain.Entity.Product readBySKU(string sku)
        {
            return _context.Product.FirstOrDefault(x => x.SKU == sku);
        }

        public Domain.Entity.Product update(Domain.Entity.Product entity)
        {
            _context.Product.Update(entity);
            return entity;

        }
    }
}
