using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Location
{
    public interface ILocationRepository : IRepository<Domain.Entity.Location, Guid>
    {
        Domain.Entity.Location readByXYZ(decimal x, decimal y, decimal z);
    }
}
