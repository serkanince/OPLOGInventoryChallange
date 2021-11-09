using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPLOGInventory.Application.InventoryItems;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;

namespace OPLOGInventory.API.Controllers
{
    [Route("api/v1/inventoryitem")]
    [ApiController]
    [Authorize]
    public class InventoryItemController : ControllerBase
    {
        public InventoryItemController(IInventoryItemApplication inventoryItemApplication)
        {
            _inventoryItemApplication = inventoryItemApplication;
        }

        private IInventoryItemApplication _inventoryItemApplication;

        /// <summary>
        /// As an operator, I can create an Inventory Item, so that I can accept new inventory to the warehouse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = ApiUserRole.Operator)]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult CreateInventoryItem([FromForm]InventoryItemDto input)
        {
            if (input != null)
            {
                return Ok(_inventoryItemApplication.CreateProduct(input));
            }

            return NotFound();
        }
    }
}