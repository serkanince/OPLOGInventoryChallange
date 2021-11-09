using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Data.Entity
{
    public class Container 
    {
        [Key]
        public Guid ID { get; set; }

        public virtual ICollection<InventoryItem> Contents { get; set; }

        [Required]
        public Guid LocationId { get; set; }

        [Required]
        public string Label { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
