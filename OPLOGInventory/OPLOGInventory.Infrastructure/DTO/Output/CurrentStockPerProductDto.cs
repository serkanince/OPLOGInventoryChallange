using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO.Output
{
    public class CurrentStockPerProductDto
    {
        public string Name { get; set; }

        public string SKU { get; set; }

        public uint Total { get; set; }
    }
}
