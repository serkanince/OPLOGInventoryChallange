
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Model
{
    public class InventoryItemDto
    {
        /// <summary>
        /// Product SKU to define which product
        /// </summary>
        [Required]
        public string SKU { get; set; }

        /// <summary>
        /// Container Label to define in what container
        /// </summary>
        [Required]
        public string Label { get; set; }

        /// <summary>
        /// Quantity to define amount of inventory
        /// </summary>
        [Required]
        [Range(1, uint.MaxValue)]
        public uint Quantity { get; set; }

        /// <summary>
        /// Type to define the category of inventory
        /// </summary>
        [Required]
        public InventoryItemType Type { get; set; }


        public Guid ProductId { get; set; }
        public Guid ContainerId { get; set; }

    }
}
