using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Repository.SalesOrder
{
    public class SalesOrderRepository : RepositoryBase, ISalesOrderRepository
    {
        MSSQLDBContext _context;

        public SalesOrderRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.SalesOrder create(Domain.Entity.SalesOrder entity)
        {
            CheckRule(new SalesOrdersConnotSameReferenceNo(_context, entity.ReferanceNo));
            CheckRule(new SalesOrdersAvailableStockForProduct(_context, entity.LineItems.ToList()));

            _context.SalesOrder.Add(entity);
            return entity;
        }

        public Domain.Entity.SalesOrder delete(Domain.Entity.SalesOrder entity)
        {
            _context.SalesOrder.Remove(entity);
            return entity;
        }

        public IQueryable<Domain.Entity.SalesOrder> GetAll(Expression<Func<Domain.Entity.SalesOrder, bool>> predicate)
        {
            return _context.SalesOrder.Where(predicate).AsQueryable();
        }

        public Domain.Entity.SalesOrder readById(Guid id)
        {
            return _context.SalesOrder.Where(x => x.ID == id).FirstOrDefault();
        }

        public Domain.Entity.SalesOrder readByReferenceNo(string referenceNo)
        {
            return _context.SalesOrder.Where(x => x.ReferanceNo == referenceNo).FirstOrDefault();
        }

        public Domain.Entity.SalesOrder update(Domain.Entity.SalesOrder entity)
        {
            _context.SalesOrder.Update(entity);
            return entity;
        }

        public ICollection<Domain.Entity.SalesOrder> update(ICollection<Domain.Entity.SalesOrder> entity)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.SalesOrder updateCancelStatus(Domain.Entity.SalesOrder entity)
        {
            CheckRule(new SalesOrdersNotBeenShippedYet(entity.IsShipped));
            CheckRule(new SalesOrdersCancelledOnylyOnce(entity.CancelledDate));

            entity.CancelledDate = DateTime.Now;

            return entity;
        }

        public Domain.Entity.SalesOrder updateShippedStatus(Domain.Entity.SalesOrder entity)
        {
            CheckRule(new SalesOrderCanceledConnotBeShipped(entity.CancelledDate));
            CheckRule(new SalesOrderOnlyOnceShipped(entity.IsShipped));


            entity.IsShipped = true;
            entity.ShippedDate = DateTime.Now;

            _context.SalesOrder.Update(entity);

            return entity;
        }

        IQueryable<Domain.Entity.SalesOrder> IRepository<Domain.Entity.SalesOrder, Guid>.GetAll()
        {
            return _context.SalesOrder.AsQueryable();
        }
    }
}
