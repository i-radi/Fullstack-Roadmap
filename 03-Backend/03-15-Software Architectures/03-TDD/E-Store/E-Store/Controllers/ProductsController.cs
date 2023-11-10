using E_Store.Models;
using E_Store.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            if (products is null || !products.Any())
                return NotFound(Enumerable.Empty<Product>());

            return Ok(products);
        }
    }
}