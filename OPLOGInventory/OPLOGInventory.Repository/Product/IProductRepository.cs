using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Product
{
    public interface IProductRepository<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {
        Domain.Entity.Product readBySKU(string sku);
    }
}
