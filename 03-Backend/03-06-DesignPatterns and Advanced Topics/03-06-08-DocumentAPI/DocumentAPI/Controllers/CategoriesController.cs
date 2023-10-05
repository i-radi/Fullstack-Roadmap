using Microsoft.AspNetCore.Mvc;

namespace DocumentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult List()
        {
            return Ok();
        }
    }
}
