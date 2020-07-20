using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.Rules
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
