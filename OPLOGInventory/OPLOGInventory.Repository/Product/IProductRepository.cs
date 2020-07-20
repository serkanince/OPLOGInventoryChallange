using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Product
{
    public interface IProductRepository : IRepository<Domain.Entity.Product, Guid>
    {
        Domain.Entity.Product readBySKU(string sku);
    }
}
