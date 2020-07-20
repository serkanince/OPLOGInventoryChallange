using OPLOGInventory.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OPLOGInventory.Domain.Entity
{
    public class InventoryItem
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public Guid? LineItemId { get; set; }

        [ForeignKey("LineItemId")]
        public virtual LineItem LineItem { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        [Required]
        public Guid ContainerId { get; set; }

        [ForeignKey("ContainerId")]
        public virtual Container Container { get; set; }

        //[Required]
        //[]
        //public uint Quantity { get; set; }

        //[Required]
        //public uint StockQuantity { get; set; }

        [Required]
        public InventoryItemType Type { get; set; }

    }
}
