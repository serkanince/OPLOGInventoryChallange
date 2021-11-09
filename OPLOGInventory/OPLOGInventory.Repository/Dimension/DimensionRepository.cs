using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Data.DB;
using OPLOGInventory.Repository.Container;

namespace OPLOGInventory.Repository.Dimension
{
    public class DimensionRepository : RepositoryCrud<Data.Entity.Dimension>, IDimensionRepository
    {
        PostgreSqlDBContext _context;

        public DimensionRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

        public Data.Entity.Container ReadByLabel(string label)
        {
            throw new NotImplementedException();
        }
    }
}
