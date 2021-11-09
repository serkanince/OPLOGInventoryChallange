using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.ApiUser
{
    public interface IApiUserRepository : IRepositoryCrud<Domain.Entity.ApiUser>
    {
        Domain.Entity.ApiUser getApiUserByUsernameandPass(string username, string password);
    }
}
