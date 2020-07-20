using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Infrastructure.DTO
{
    public class ContainerDto
    {

        [Required]
        public string Label { get; set; }

        [Required]
        public virtual LocationDto Location { get; set; }
    }
}
