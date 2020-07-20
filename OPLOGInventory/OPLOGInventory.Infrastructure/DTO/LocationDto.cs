using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class LocationDto
    {
        [Required]
        public decimal x { get; set; }

        [Required]
        public decimal y { get; set; }

        [Required]
        public decimal z { get; set; }
    }
}
