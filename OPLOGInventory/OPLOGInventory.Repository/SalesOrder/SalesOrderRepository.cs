﻿using OPLOGInventory.Data.DB;
using OPLOGInventory.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OPLOGInventory.Repository.SalesOrder
{
    public class SalesOrderRepository : RepositoryCrud<Data.Entity.SalesOrder>, ISalesOrderRepository
    {
        PostgreSqlDBContext _context;

        public SalesOrderRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

        public Data.Entity.SalesOrder readByReferenceNo(string referenceNo)
        {
            return _context.SalesOrder.Where(x => x.ReferanceNo == referenceNo).FirstOrDefault();
        }

        public Data.Entity.SalesOrder updateCancelStatus(Data.Entity.SalesOrder entity)
        {
            CheckRule(new SalesOrdersNotBeenShippedYet(entity.IsShipped));
            CheckRule(new SalesOrdersCancelledOnylyOnce(entity.CancelledDate));

            entity.CancelledDate = DateTime.Now;

            return entity;
        }

        public Data.Entity.SalesOrder updateShippedStatus(Data.Entity.SalesOrder entity)
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
