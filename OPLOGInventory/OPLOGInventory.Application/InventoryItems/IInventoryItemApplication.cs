using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.InventoryItems
{
    public interface IInventoryItemApplication
    {
        IResult CreateProduct(InventoryItemDto input);
    }
}
