using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OPLOGInventory.Application.QueryApplications;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Infrastructure.DTO.Output;

namespace OPLOGInventory.API.Controllers
{
    [Route("api/v1/query")]
    [ApiController]
    [Authorize]
    public class QueryController : ControllerBase
    {
        public QueryController(IQueryApplication queryApplication)
        {
            _queryApplication = queryApplication;
        }

        private IQueryApplication _queryApplication;

        /// <summary>
        /// As an authorized user, I can query current stock per container, so that I can learn how many products in which location
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("current-stock-per-container")]
        [ProducesResponseType(typeof(IDataResult<List<QueryContainerListDto>>), 200)]
        public IActionResult CurrentStockPerContainer()
        {
            return Ok(_queryApplication.CurrentStockPerContainer());
        }

        /// <summary>
        /// As an authorized user, I can query current stock per product, so that I can learn how many products in total stock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("current-stock-per-product")]
        [ProducesResponseType(typeof(IDataResult<List<CurrentStockPerProductDto>>), 200)]
        public IActionResult CurrentStockPerProduct()
        {
            return Ok(_queryApplication.CurrentStockPerProduct());
        }

        /// <summary>
        /// As an authorized user, I can query available stock per product, so that I can learn how many available products in total stock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("current-stock-in-stock")]
        [ProducesResponseType(typeof(IDataResult<List<CurrentStockPerProductDto>>), 200)]
        public IActionResult CurrentStockInStockType()
        {
            return Ok(_queryApplication.CurrentStockInStock());
        }


    }
}