using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Data.Entity
{
    public class Barcode
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
