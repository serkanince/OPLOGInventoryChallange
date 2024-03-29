﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Data.DB;

namespace OPLOGInventory.Repository.Location
{
    public class LocationRepository : RepositoryCrud<Data.Entity.Location>, ILocationRepository
    {
        PostgreSqlDBContext _context;

        public LocationRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }
        public Data.Entity.Location readByXYZ(decimal x, decimal y, decimal z)
        {
            return _context.Location.Where(l => l.x == x && l.y == y && l.z == z).FirstOrDefault();
        }



    }
}
