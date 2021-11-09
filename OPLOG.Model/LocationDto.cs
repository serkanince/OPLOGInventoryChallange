using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Model
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
