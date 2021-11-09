using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.Container
{
    public class ContainerRepository : RepositoryCrud<Data.Entity.Container>, IContainerRepository
    {
        PostgreSqlDBContext _context;

        public ContainerRepository(PostgreSqlDBContext context) : base(context : context)
        {
            _context = context;
        }

        public Data.Entity.Container ReadByLabel(string label)
        {
            return _context.Container.Where(x => x.Label == label).FirstOrDefault();
        }
    }
}
