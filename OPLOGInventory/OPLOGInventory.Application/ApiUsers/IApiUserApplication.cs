using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.ApiUsers
{
    public interface IApiUserApplication
    {
        IDataResult<ApiUserDto> GetApiUser(LoginDto input);
    }
}
