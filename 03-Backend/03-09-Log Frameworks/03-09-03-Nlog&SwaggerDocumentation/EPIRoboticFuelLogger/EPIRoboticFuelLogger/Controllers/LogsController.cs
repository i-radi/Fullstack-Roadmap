using EPIRoboticFuelLogger.Extentions;
using EPIRoboticFuelLogger.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EPIRoboticFuelLogger.Controllers;

[ApiController]
[Route("[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogger<Log> _logger;

    public LogsController(ILogger<Log> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Add EPIRoboticFuelAPI log into file and database
    /// </summary>
    /// <param name="log">
    /// description: log object
    ///</param>
    /// <remarks>
    /// Sample request:
    ///
    ///     Post /Logs/EPIRoboticFuelAPI/
    ///     
    ///     Body: Json Object :
    ///     {
    ///       "message": "string",
    ///       "authorizationID": "string",
    ///       "responseCode": 0,
    ///       "responseMessage": "string",
    ///       "responseTime": "2023-08-21T08:26:12.643Z",
    ///       "fuelingStartTime": "2023-08-21T08:26:12.643Z",
    ///       "accessToken": "string",
    ///       "userAccountID": 0
    ///     }
    ///     
    ///     message must be StartFueling, FuelingStarted, StopFueling, or LoginRubyAI.
    ///
    ///  </remarks>
    [Produces("Application/JSON")]
    [HttpPost("EPIRoboticFuelAPI")]
    public IActionResult CreateEPIRoboticFuelAPI(Log log)
    {
        try
        {
            var serializedLog = JsonConvert.SerializeObject(log.Mapping());
            _logger.LogInformation(serializedLog);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}