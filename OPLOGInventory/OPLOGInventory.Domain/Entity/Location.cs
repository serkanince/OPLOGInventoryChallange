using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Domain.Entity
{
    public class Location 
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public decimal x { get; set; }

        [Required]
        public decimal y { get; set; }

        [Required]
        public decimal z { get; set; }

        public virtual ICollection<Container> LocatedContainers { get; set; }
    }
}
