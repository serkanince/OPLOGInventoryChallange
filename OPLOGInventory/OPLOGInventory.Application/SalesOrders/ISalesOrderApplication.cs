using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Infrastructure.DTO;
using OPLOGInventory.Infrastructure.DTO.Output;
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
