using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Infrastructure.DTO.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.QueryApplications
{
    public interface IQueryApplication
    {
        IDataResult<List<QueryContainerListDto>> CurrentStockPerContainer();
        IDataResult<List<CurrentStockPerProductDto>> CurrentStockPerProduct();

        IDataResult<List<CurrentStockPerProductDto>> CurrentStockInStock();
    }
}
