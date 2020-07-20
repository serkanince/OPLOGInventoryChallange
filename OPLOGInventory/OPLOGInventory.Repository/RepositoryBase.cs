using OPLOGInventory.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository
{
    public abstract class RepositoryBase
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
