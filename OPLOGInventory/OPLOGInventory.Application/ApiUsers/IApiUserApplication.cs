using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Infrastructure.DTO;
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
