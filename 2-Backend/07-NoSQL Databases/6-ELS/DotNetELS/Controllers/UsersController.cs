using DotNetELS.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace DotNetELS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly ILogger<ProductsController> _logger;
        private readonly IConfiguration _configuration;
        public UsersController(
            IElasticClient elasticClient,
            ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _elasticClient = elasticClient;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> Get(string keyword)
        {
            var result = await _elasticClient.SearchAsync<User>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                    )).Index(_configuration["ELKConfiguration:UserIndex"]).Size(1000));

            _logger.LogInformation("UsersController Get - ", DateTime.UtcNow);
            return Ok(result.Documents.ToList());
        }

        [HttpPost(Name = "AddUser")]
        public IActionResult Post(User user)
        {
            var res = _elasticClient.Index(user,
                u => u.Index(_configuration["ELKConfiguration:UserIndex"]));

            _logger.LogInformation("UsersController Post - ", DateTime.UtcNow);
            return Ok();
        }
    }
}
