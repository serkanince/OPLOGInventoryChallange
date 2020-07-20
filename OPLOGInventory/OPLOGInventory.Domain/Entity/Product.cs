using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Domain.Entity
{
    public class Product 
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public virtual ICollection<Barcode> Barcodes { get; set; }

        [Required]
        public Guid? DimensionId { get; set; }

        [ForeignKey("DimensionId")]
        public virtual Dimension Dimension { get; set; }

        public string ImageUrl { get; set; }

        
    }
}
