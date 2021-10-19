using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.LineItem
{
    public interface ILineItemRepository<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {

    }
}
