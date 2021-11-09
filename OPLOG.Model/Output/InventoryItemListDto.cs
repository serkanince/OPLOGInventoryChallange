
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Model.Output
{
    public class InventoryItemListDto
    {
        public ContainerListDto Container { get; set; }

        public ProductListDto Product { get; set; }

        public InventoryItemType Type { get; set; }
    }
}
