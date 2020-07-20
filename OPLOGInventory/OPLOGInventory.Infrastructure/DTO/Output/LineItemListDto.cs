using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO.Output
{
    public class LineItemListDto
    {
        //public ProductListDto Product { get; set; }

        public List<InventoryItemListDto> InventoryItems { get; set; }

        public uint Quantity { get; set; }
    }
}
