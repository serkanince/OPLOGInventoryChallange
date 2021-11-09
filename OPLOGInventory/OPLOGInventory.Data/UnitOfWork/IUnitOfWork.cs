using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Data.UOW
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
