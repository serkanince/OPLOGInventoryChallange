using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OPLOGInventory.Repository.SalesOrder
{
    public class SalesOrderRepository<TEntity> : RepositoryCrud<TEntity>, ISalesOrderRepository<TEntity> where TEntity : class
    {
        PostgreSqlDBContext _context;

        public SalesOrderRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

        public Domain.Entity.SalesOrder readByReferenceNo(string referenceNo)
        {
            return _context.SalesOrder.Where(x => x.ReferanceNo == referenceNo).FirstOrDefault();
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

    }
}
