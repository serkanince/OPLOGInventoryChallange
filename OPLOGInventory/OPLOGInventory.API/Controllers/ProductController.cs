using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OPLOGInventory.Application.Products;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;

namespace OPLOGInventory.API.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        private IProductApplication _productApplication;


        /// <summary>
        /// As an authorized user, I can create Product, so that the product can be stored in the warehouse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult CreateProduct([FromForm]ProductDto input)
        {
            if (input != null)
                return Ok(_productApplication.CreateProduct(input));
            else
                return NotFound();
        }

        /// <summary>
        /// As an authorized user, I can delete Product, so that the product catalog can stay clear
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(IResult), 200)]
        public IActionResult DeleteProduct([FromForm]string sku)
        {
            if (!string.IsNullOrEmpty(sku))
                return Ok(_productApplication.DeleteProduct(sku));
            else
                return NoContent();
        }

    }
}