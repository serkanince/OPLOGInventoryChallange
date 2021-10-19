using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Location
{
    public interface ILocationRepository<TEntity> : IRepositoryCrud<TEntity> where TEntity : class
    {
        Domain.Entity.Location readByXYZ(decimal x, decimal y, decimal z);
    }
}
