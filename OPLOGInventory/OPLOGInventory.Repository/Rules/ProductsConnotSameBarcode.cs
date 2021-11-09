using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class ProductsConnotSameBarcode : IBusinessRule
    {
        private readonly PostgreSqlDBContext _context;
        private readonly List<string> _barcodes;
        private string _sameBarcode;

        public ProductsConnotSameBarcode(PostgreSqlDBContext context, List<string> barcodes)
        {
            _barcodes = barcodes;
            _context = context;
        }


        public string Message => "A product with the same barcode defined in the system already cannot be created. Same Barcode : " + _sameBarcode;

        public bool IsBroken()
        {
            foreach (var brcd in _barcodes)
            {
                if (_context.Barcode.Where(x => x.Label.Contains(brcd)).Any())
                {
                    _sameBarcode = brcd;
                    return true;
                }
            }

            return false;
        }
    }
}
