using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.Container
{
    public class ContainerRepository : RepositoryCrud<Domain.Entity.Container>, IContainerRepository
    {
        PostgreSqlDBContext _context;

        public ContainerRepository(PostgreSqlDBContext context) : base(context : context)
        {
            _context = context;
        }

        public Domain.Entity.Container ReadByLabel(string label)
        {
            return _context.Container.Where(x => x.Label == label).FirstOrDefault();
        }
    }
}
