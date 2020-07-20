using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;

namespace OPLOGInventory.Repository.LineItem
{
    public class LineItemRepository : ILineItemRepository
    {
        public Domain.Entity.LineItem create(Domain.Entity.LineItem entity)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.LineItem delete(Domain.Entity.LineItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entity.LineItem> GetAll(Expression<Func<Domain.Entity.LineItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.LineItem readById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.LineItem update(Domain.Entity.LineItem entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<Domain.Entity.LineItem> IRepository<Domain.Entity.LineItem, Guid>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
