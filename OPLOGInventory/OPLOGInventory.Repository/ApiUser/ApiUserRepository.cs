using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DB;

namespace OPLOGInventory.Repository.ApiUser
{
    public class ApiUserRepository : IApiUserRepository
    {
        MSSQLDBContext _context;

        public ApiUserRepository(MSSQLDBContext context)
        {
            _context = context;
        }

        public Domain.Entity.ApiUser getApiUserByUsernameandPass(string username, string password)
        {
            return _context.ApiUser.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
