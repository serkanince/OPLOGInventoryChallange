using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrderOnlyOnceShipped : IBusinessRule
    {
        private bool _isShipped;

        public SalesOrderOnlyOnceShipped(bool isShipped)
        {
            _isShipped = isShipped;
        }

        public string Message => "A Sales Order can be shipped from warehouse only once.";

        public bool IsBroken()
        {
            return _isShipped;
        }
    }
}
