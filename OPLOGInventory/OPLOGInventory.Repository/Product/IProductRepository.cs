using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Product
{
    public interface IProductRepository : IRepositoryCrud<Data.Entity.Product>
    {
        Data.Entity.Product readBySKU(string sku);
    }
}
