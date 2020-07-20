using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.UOW
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
