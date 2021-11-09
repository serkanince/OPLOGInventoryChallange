using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Application.SalesOrders;
using OPLOGInventory.Model;
using OPLOGInventory.Model.Output;
using Swashbuckle.Swagger.Annotations;

namespace OPLOGInventory.API.Controllers
{
    [Route("api/v1/salesorder")]
    [ApiController]
    [Authorize]

    public class SalesOrderController : ControllerBase
    {
        public SalesOrderController(ISalesOrderApplication salesorderApplication)
        {
            _salesorderApplication = salesorderApplication;
        }

        private ISalesOrderApplication _salesorderApplication;

        /// <summary>
        /// As a seller, I can create Sales Orders, so that I can reserve inventory in the system
        /// </summary>
        /// <param name="input">SalesOrderDto</param>
        /// <returns></returns>
        [Authorize(Roles = ApiUserRole.Seller)]
        [HttpPost]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult CreateSalesOrder([FromForm]SalesOrderDto input)
        {
            if (input != null)
                return Ok(_salesorderApplication.CreateSalesOrder(input));
            else
                return NotFound();
        }

        /// <summary>
        /// As an operator, I can ship Sales Orders, so that I can send reserved products to end customers
        /// </summary>
        /// <param name="referenceNo"></param>
        /// <returns></returns>
        [Authorize(Roles = ApiUserRole.Operator)]
        [Route("ship-salesorder")]
        [HttpPut]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult ShipSalesOrder([FromForm]string referenceNo)
        {
            if (!string.IsNullOrEmpty(referenceNo))
                return Ok(_salesorderApplication.ShipSalesOrder(referenceNo));
            else
                return NotFound();
        }

        /// <summary>
        /// As a seller, I can cancel a Sales Order, so that I can unreserve some inventory in the system
        /// </summary>
        /// <param name="referenceNo"></param>
        /// <returns></returns>
        [Authorize(Roles = ApiUserRole.Seller)]
        [Route("cancel-salesorder")]
        [HttpPut]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult CancelSalesOrder([FromForm]string referenceNo)
        {
            if (!string.IsNullOrEmpty(referenceNo))
                return Ok(_salesorderApplication.CancelSalesOrder(referenceNo));
            else
                return NotFound();
        }

        /// <summary>
        /// As an authorized user, I can list Sales Orders, so that I can see Sales Orders and its reserved stock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IDataResult<List<SalesOrderListDto>>), 200)]
        public IActionResult ListSalesOrder()
        {
            return Ok(_salesorderApplication.ListSalesOrder());
        }
    }
}