using OPLOGInventory.Data.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrderCanceledConnotBeShipped : IBusinessRule
    {

        private DateTime? _cancelletionDate;

        public SalesOrderCanceledConnotBeShipped(DateTime? cancelletionDate)
        {
            _cancelletionDate = cancelletionDate;
        }

        public string Message => "A Sales Order is cancelled, it cannot be shipped from warehouse.";

        public bool IsBroken()
        {
            return _cancelletionDate.HasValue;
        }
    }
}
