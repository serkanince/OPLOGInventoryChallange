using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Model.Output
{
    public class ProductListDto
    {
        
        public string Name { get; set; }

        public string SKU { get; set; }

        public List<BarcodeListDto> Barcodes { get; set; }

        public DimensionListDto Dimension { get; set; }

        public string ImageUrl { get; set; }
    }
}
