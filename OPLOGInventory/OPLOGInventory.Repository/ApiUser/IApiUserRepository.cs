using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Repository.ApiUser
{
    public interface IApiUserRepository
    {
        Domain.Entity.ApiUser getApiUserByUsernameandPass(string username,string password);
    }
}
