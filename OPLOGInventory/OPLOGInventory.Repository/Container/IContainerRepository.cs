using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Container
{
    public interface IContainerRepository : IRepositoryCrud<Data.Entity.Container>
    {
        Data.Entity.Container ReadByLabel(string label);
    }
}
