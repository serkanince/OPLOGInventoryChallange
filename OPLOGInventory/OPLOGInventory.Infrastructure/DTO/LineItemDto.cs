using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class LineItemDto
    {
        [Required]
        public string ProductSKU { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        public uint Quantity { get; set; }
    }
}
