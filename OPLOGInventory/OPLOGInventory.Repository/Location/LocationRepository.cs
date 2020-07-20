using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.Location
{
    public class LocationRepository : ILocationRepository
    {
        MSSQLDBContext _context;

        public LocationRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.Location create(Domain.Entity.Location entity)
        {
            _context.Location.Add(entity);
            return entity;
        }

        public Domain.Entity.Location delete(Domain.Entity.Location entity)
        {
            _context.Location.Remove(entity);
            return entity;
        }


        public IQueryable<Domain.Entity.Location> GetAll(Expression<Func<Domain.Entity.Location, bool>> predicate)
        {
            return _context.Location.Where(predicate).AsQueryable();
        }

        public Domain.Entity.Location readById(Guid id)
        {
            return _context.Location.Where(x => x.ID == id).FirstOrDefault();
        }

        public Domain.Entity.Location readByXYZ(decimal x, decimal y, decimal z)
        {
            return _context.Location.Where(l => l.x == x && l.y == y && l.z == z).FirstOrDefault();
        }

        public Domain.Entity.Location update(Domain.Entity.Location entity)
        {
            _context.Location.Update(entity);
            return entity;
        }

        IQueryable<Domain.Entity.Location> IRepository<Domain.Entity.Location, Guid>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
