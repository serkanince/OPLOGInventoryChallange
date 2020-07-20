﻿using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public class ProductsConnotDeleteDefinedSalesOrder : IBusinessRule
    {
        private readonly MSSQLDBContext _context;
        private readonly Guid _productId;

        public ProductsConnotDeleteDefinedSalesOrder(MSSQLDBContext context, Guid productId)
        {
            _context = context;
            _productId = productId;
        }

        public string Message => "A product with a Sales Order Line Item defined in the system cannot be deleted.";

        public bool IsBroken()
        {
            return _context.LineItem.Where(x => x.ProductId == _productId).Any();
        }
    }
}
