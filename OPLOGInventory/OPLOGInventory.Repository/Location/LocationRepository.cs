using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.Location
{
    public class LocationRepository<TEntity> : RepositoryCrud<TEntity>, ILocationRepository<TEntity> where TEntity : class
    {
        PostgreSqlDBContext _context;

        public LocationRepository(PostgreSqlDBContext context) : base(context : context)
        {
            _context = context;
        }
        public Domain.Entity.Location readByXYZ(decimal x, decimal y, decimal z)
        {
            return _context.Location.Where(l => l.x == x && l.y == y && l.z == z).FirstOrDefault();
        }



    }
}
