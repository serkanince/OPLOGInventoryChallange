using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.Containers
{
    public interface IContainerApplication
    {
        IResult MoveContainer(ContainerDto input);
    }
}
