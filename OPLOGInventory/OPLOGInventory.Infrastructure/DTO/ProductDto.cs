using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class ProductDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public  List<BarcodeDto> Barcodes { get; set; }

        public DimensionDto Dimension { get; set; }

        public string ImageUrl { get; set; }
    }
}
