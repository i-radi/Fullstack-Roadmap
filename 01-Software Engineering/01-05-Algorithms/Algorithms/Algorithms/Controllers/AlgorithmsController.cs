using Algorithms.Services;
using Microsoft.AspNetCore.Mvc;

namespace Algorithms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlgorithmsController : ControllerBase
    {
        private readonly ILogger<AlgorithmsController> _logger;
        private readonly IAlgorithmService _algorithmService;

        public AlgorithmsController(ILogger<AlgorithmsController> logger, IAlgorithmService algorithmService)
        {
            _logger = logger;
            _algorithmService = algorithmService;
        }

        [HttpGet("CalcStandardDeviation")]
        public IActionResult CalcStandardDeviation([FromQuery] List<double> values)
        {
            return Ok(_algorithmService.CalcStandardDeviation(values));
        }

        [HttpGet("CalcCorrelation")]
        public IActionResult CalcCorrelation([FromQuery] List<double> xValues, [FromQuery] List<double> yValues)
        {
            if (xValues.Count() != yValues.Count())
            {
                return BadRequest("invalid data");
            }
            return Ok(_algorithmService.CalcCorrelation(xValues, yValues));
        }

        [HttpGet("MergeSort")]
        public IActionResult MergeSort([FromQuery] int[] array)
        {
            _algorithmService.MergeSort(array, 0, array.Length - 1);
            return Ok(array);
        }

        [HttpGet("BinarySearch")]
        public IActionResult BinarySearchAlgorithm([FromQuery] int[] array, int target)
        {
            return Ok(_algorithmService.BinarySearchAlgorithm(array, target));
        }

        [HttpGet("SegregatePositiveAndNegativeNumbers")]
        public IActionResult SegregatePositiveAndNegativeNumbers([FromQuery] int[] array)
        {
            _algorithmService.SegregatePositiveAndNegativeNumbers(array, 0, array.Length - 1);
            return Ok(array);
        }

    }
}