using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Data.Entity
{
    public class LineItem
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }

        //[Required]
        //public Guid InventoryItemId { get; set; }

        //[ForeignKey("InventoryItemId")]
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }


        [Required]
        public Guid SalesOrderId { get; set; }

        [ForeignKey("SalesOrderId")]
        public virtual SalesOrder SalesOrder { get; set; }


        [Required]
        public uint Quantity { get; set; }
    }
}
