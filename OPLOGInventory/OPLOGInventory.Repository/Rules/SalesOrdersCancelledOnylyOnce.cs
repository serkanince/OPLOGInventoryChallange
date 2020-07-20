using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrdersCancelledOnylyOnce : IBusinessRule
    {
        private DateTime? _cancelledDate;
        public SalesOrdersCancelledOnylyOnce(DateTime? cancelledDate)
        {
            _cancelledDate = cancelledDate;
        }

        public string Message => "A Sales Order can be cancelled only once.";

        public bool IsBroken()
        {
            return _cancelledDate.HasValue;
        }
    }
}
