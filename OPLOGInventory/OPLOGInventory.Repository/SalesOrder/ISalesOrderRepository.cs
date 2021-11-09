using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.SalesOrder
{
    public interface ISalesOrderRepository: IRepositoryCrud<Data.Entity.SalesOrder>
    {
        Data.Entity.SalesOrder readByReferenceNo(string referenceNo);
        Data.Entity.SalesOrder updateShippedStatus(Data.Entity.SalesOrder entity);

        Data.Entity.SalesOrder updateCancelStatus(Data.Entity.SalesOrder entity);
    }
}
