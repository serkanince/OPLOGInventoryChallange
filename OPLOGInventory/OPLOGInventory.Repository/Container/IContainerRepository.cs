using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Container
{
    public interface IContainerRepository<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {
        Domain.Entity.Container ReadByLabel(string label);
    }
}
