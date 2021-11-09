using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OPLOGInventory.Application.Containers;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;

namespace OPLOGInventory.API.Controllers
{
    [Route("api/v1/container")]
    [ApiController]
    [Authorize]
    public class ContainerController : ControllerBase
    {
        public ContainerController(IContainerApplication containerApplication)
        {
            _containerApplication = containerApplication;
        }

        private IContainerApplication _containerApplication;

        /// <summary>
        /// As an operator, I can move a Container to another Location, so that I organize inventory in the warehouse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = ApiUserRole.Operator)]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult MoveContainer([FromForm]ContainerDto input)
        {
            if (input != null)
            {
                return Ok(_containerApplication.MoveContainer(input));
            }

            return NotFound();
        }
    }
}