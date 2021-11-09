using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OPLOGInventory.Data.Entity
{
    public class SalesOrder 
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        
        public string ReferanceNo { get; set; }

        [Required]
        public bool IsShipped { get; set; }
        
        [Required]
        public virtual ICollection<LineItem> LineItems { get; set; }

        public DateTime? CancelledDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string ReceiverAddress { get; set; }
    }
}
