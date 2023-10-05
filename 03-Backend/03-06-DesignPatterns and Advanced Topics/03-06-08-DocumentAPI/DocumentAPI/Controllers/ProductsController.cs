using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocumentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "List Of Products", OperationId = "List", Description = "<h1>Details<h1> <h3>Products Endpoints<h3> <b>notes</b> ", Tags = new[] { "Products" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult List()
        {
            return Ok();
        }
    }
}
