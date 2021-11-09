using AutoMapper;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Model;
using OPLOGInventory.Infrastructure.UOW;
using OPLOGInventory.Repository.ApiUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.ApiUsers
{
    public class ApiUserApplication : IApiUserApplication
    {
        public ApiUserApplication(IUnitOfWork uow, IMapper mapper, IApiUserRepository apiuserrepository)

        {
            _apiuserrepository = apiuserrepository;
            _mapper = mapper;
        }

        private IMapper _mapper { get; }
        private IApiUserRepository _apiuserrepository { get; }

        public IDataResult<ApiUserDto> GetApiUser(LoginDto input)
        {
            var entity = _apiuserrepository.getApiUserByUsernameandPass(input.Username, input.Password);

            if (entity != null)

                return DataResult<ApiUserDto>.Success(_mapper.Map<ApiUser, ApiUserDto>(entity));
            else
                return DataResult<ApiUserDto>.Error();
        }
    }
}
