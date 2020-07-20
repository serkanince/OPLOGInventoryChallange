using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Container
{
    public interface IContainerRepository : IRepository<Domain.Entity.Container,Guid>
    {
        Domain.Entity.Container readByLabel(string label);
    }
}
