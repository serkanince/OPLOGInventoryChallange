using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DTO;
using OPLOGInventory.Infrastructure.UOW;
using OPLOGInventory.Repository.Container;
using OPLOGInventory.Repository.Location;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Application.Containers
{
    public class ContainerApplication : IContainerApplication
    {
        public ContainerApplication(IUnitOfWork uow, IMapper mapper, IContainerRepository<Container> containerRepository, ILocationRepository<Location> locationRepository)
        {
            _unitofwork = uow;
            _mapper = mapper;
            _containerRepository = containerRepository;
            _locationRepository = locationRepository;
        }

        private IMapper _mapper { get; }
        private IUnitOfWork _unitofwork { get; }

        private IContainerRepository<Container> _containerRepository { get; }

        private ILocationRepository<Location> _locationRepository { get; }

        public IResult MoveContainer(ContainerDto input)
        {
            try
            {
                var container = _containerRepository.ReadByLabel(input.Label);

                if (container == null)
                    return Result.Error("Container Label it is not fount !");


                var location = _locationRepository.readByXYZ(input.Location.x, input.Location.y, input.Location.z);

                if (location == null)
                    location = _locationRepository.Insert(_mapper.Map<LocationDto, Location>(input.Location));


                container.LocationId = location.ID;

                _containerRepository.Update(container);

                _unitofwork.SaveChanges();

                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }
    }
}
