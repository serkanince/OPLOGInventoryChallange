using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;
using OPLOGInventory.Model.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.SalesOrders
{
    public interface ISalesOrderApplication
    {
        IResult CreateSalesOrder(SalesOrderDto input);

        IDataResult<List<SalesOrderListDto>> ListSalesOrder();

        IResult CancelSalesOrder(string referenceNo);

        IResult ShipSalesOrder(string referenceNo);
    }
}
