using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Location
{
    public interface ILocationRepository : IRepositoryCrud<Domain.Entity.Location> 
    {
        Domain.Entity.Location readByXYZ(decimal x, decimal y, decimal z);
    }
}
