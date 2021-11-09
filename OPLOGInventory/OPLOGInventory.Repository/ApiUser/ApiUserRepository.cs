using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Data.DB;

namespace OPLOGInventory.Repository.ApiUser
{
    public class ApiUserRepository : RepositoryCrud<Data.Entity.ApiUser>, IApiUserRepository
    {
        PostgreSqlDBContext _context;

        public ApiUserRepository(PostgreSqlDBContext context) : base(context: context)
        {
            _context = context;
        }

        public Data.Entity.ApiUser getApiUserByUsernameandPass(string username, string password)
        {
            return _context.ApiUser.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
