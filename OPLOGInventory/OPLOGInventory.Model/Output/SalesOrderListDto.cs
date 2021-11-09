using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Model.Output
{
    public class SalesOrderListDto
    {
        public string ReferanceNo { get; set; }

        public bool IsShipped { get; set; }


        public DateTime? CancelledDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverAddress { get; set; }

        public List<LineItemListDto> LineItems { get; set; }

    }
}
