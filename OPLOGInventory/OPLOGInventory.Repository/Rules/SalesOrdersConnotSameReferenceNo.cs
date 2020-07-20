using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class SalesOrdersConnotSameReferenceNo : IBusinessRule
    {
        private readonly MSSQLDBContext _context;
        private readonly string _referenceNo;

        public SalesOrdersConnotSameReferenceNo(MSSQLDBContext context, string referenceNo)
        {
            _referenceNo = referenceNo;
            _context = context;
        }

        public string Message => "A Sales Order with the same ReferenceNo defined in the system cannot be created.";

        public bool IsBroken()
        {
            return _context.SalesOrder.Where(x => x.ReferanceNo == _referenceNo).Any();
        }
    }
}
