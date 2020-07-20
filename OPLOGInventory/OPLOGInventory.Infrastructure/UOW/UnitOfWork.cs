using OPLOGInventory.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private MSSQLDBContext _context { get; }
        public UnitOfWork(MSSQLDBContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }
    }
}
