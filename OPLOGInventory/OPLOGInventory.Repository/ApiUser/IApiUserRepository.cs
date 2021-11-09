using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.ApiUser
{
    public interface IApiUserRepository : IRepositoryCrud<Data.Entity.ApiUser>
    {
        Data.Entity.ApiUser getApiUserByUsernameandPass(string username, string password);
    }
}
