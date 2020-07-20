using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;

namespace OPLOGInventory.Repository.Dimension
{
    public class DimensionRepository : IDimensionRepository
    {
        public Domain.Entity.Dimension create(Domain.Entity.Dimension entity)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.Dimension delete(Domain.Entity.Dimension entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entity.Dimension> GetAll(Expression<Func<Domain.Entity.Dimension, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.Dimension readById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Domain.Entity.Dimension update(Domain.Entity.Dimension entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<Domain.Entity.Dimension> IRepository<Domain.Entity.Dimension, Guid>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
