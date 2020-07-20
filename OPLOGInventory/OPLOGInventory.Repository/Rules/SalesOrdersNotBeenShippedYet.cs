using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrdersNotBeenShippedYet : IBusinessRule
    {
        private bool _shippedStatus;
        public SalesOrdersNotBeenShippedYet(bool shippedStatus)
        {
            _shippedStatus = shippedStatus;
        }

        public string Message => "A Sales Order can be cancelled if it’s not been shipped yet.";

        public bool IsBroken()
        {
            return _shippedStatus;
        }
    }
}
