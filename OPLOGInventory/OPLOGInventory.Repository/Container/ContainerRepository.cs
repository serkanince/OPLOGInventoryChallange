using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.Container
{
    public class ContainerRepository : IContainerRepository
    {
        MSSQLDBContext _context;

        public ContainerRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.Container create(Domain.Entity.Container entity)
        {
            _context.Container.Add(entity);
            return entity;
        }

        public Domain.Entity.Container delete(Domain.Entity.Container entity)
        {
            _context.Container.Remove(entity);
            return entity;
        }

        public IQueryable<Domain.Entity.Container> GetAll(Expression<Func<Domain.Entity.Container, bool>> predicate)
        {
            return _context.Container.Where(predicate).AsQueryable();
        }

        public Domain.Entity.Container readById(Guid id)
        {
            return _context.Container.Where(x => x.ID == id).FirstOrDefault();
        }

        public Domain.Entity.Container readByLabel(string label)
        {
            return _context.Container.Where(x => x.Label == label).FirstOrDefault();
        }

        public Domain.Entity.Container update(Domain.Entity.Container entity)
        {
            _context.Container.Update(entity);
            return entity;
        }

        IQueryable<Domain.Entity.Container> IRepository<Domain.Entity.Container, Guid>.GetAll()
        {
            return _context.Container.AsQueryable();
        }
    }
}
