using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.SalesOrder
{
    public interface ISalesOrderRepository : IRepository<Domain.Entity.SalesOrder, Guid>
    {
        Domain.Entity.SalesOrder readByReferenceNo(string referenceNo);
        Domain.Entity.SalesOrder updateShippedStatus(Domain.Entity.SalesOrder entity);

        Domain.Entity.SalesOrder updateCancelStatus(Domain.Entity.SalesOrder entity);
    }
}
