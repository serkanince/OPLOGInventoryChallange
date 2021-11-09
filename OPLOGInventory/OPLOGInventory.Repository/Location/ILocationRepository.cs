using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Location
{
    public interface ILocationRepository : IRepositoryCrud<Data.Entity.Location> 
    {
        Data.Entity.Location readByXYZ(decimal x, decimal y, decimal z);
    }
}
