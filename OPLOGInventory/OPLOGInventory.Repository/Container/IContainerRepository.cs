using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Container
{
    public interface IContainerRepository : IRepositoryCrud<Domain.Entity.Container>
    {
        Domain.Entity.Container ReadByLabel(string label);
    }
}
