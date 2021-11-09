using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Product
{
    public interface IProductRepository : IRepositoryCrud<Domain.Entity.Product>
    {
        Domain.Entity.Product readBySKU(string sku);
    }
}
