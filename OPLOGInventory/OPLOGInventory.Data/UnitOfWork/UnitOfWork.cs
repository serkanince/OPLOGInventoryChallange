using OPLOGInventory.Data.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private PostgreSqlDBContext _context { get; }
        public UnitOfWork(PostgreSqlDBContext context)
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
