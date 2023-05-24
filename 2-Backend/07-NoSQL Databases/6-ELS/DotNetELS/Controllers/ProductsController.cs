using DotNetELS.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace DotNetELS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IElasticClient elasticClient,
            ILogger<ProductsController> logger)
        {
            _logger = logger;
            _elasticClient = elasticClient;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> Get(string keyword)
        {
            var result = await _elasticClient.SearchAsync<Product>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                    )).Size(1000));

            _logger.LogInformation("ProductsController Get - ", DateTime.UtcNow);
            return Ok(result.Documents.ToList());
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> Post(Product product)
        {
            // Index product dto
            await _elasticClient.IndexDocumentAsync(product);

            _logger.LogInformation("ProductsController Post - ", DateTime.UtcNow);
            return Ok();
        }
    }
}
