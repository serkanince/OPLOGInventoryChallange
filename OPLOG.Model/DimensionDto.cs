using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Model
{
    public class DimensionDto
    {

        [Required]

        public ProductDto Product { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Length { get; set; }
    }
}
