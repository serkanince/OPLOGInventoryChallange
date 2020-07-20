using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Domain.Entity
{
    public class Dimension 
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }

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
