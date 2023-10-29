using Algorithms.Helpers.Huffmans;
using Algorithms.Helpers.Knapsack;
using Algorithms.Requests;
using Algorithms.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpPost("ActicitySelectionProblem")]
        [SwaggerOperation(description: "{\"startArray\": [ 9, 10, 11, 12, 13, 15], \"endArray\": [ 11, 11, 12, 14, 15, 16 ]}")]
        public IActionResult ActicitySelectionProblem(ActicitySelectionProblemRequest request)
        {
            if (request.StartArray.Length != request.EndArray.Length)
            {
                return BadRequest("invalid inputs");
            }
            return Ok(_algorithmService.GreedyActivitySelector(request.StartArray, request.EndArray));
        }

        [HttpGet("SortedCharactersFrequencies")]
        public IActionResult SortedCharactersFrequencies([FromQuery] string msg)
        {
            return Ok(_algorithmService.CharFreqAnyCodeMethod(msg));
        }

        [HttpGet("Huffman'sAlgorithm")]
        [SwaggerOperation(description: "The output from Huffman's algorithm can be viewed as a variable length code table for encoding a source symbol. The algorithm derives this table from the estimated probability or frequency of occurrence for each possible value of the source symbol. as in other entropy encoding methods, more common symbols are generally represented using fewer bits than less common symbols. Huffman's method can be efficiently implemented, finding a code in time linear to the number of input weights if these weights are sorted. However, although optimal among methods encoding symbols separately, Huffman coding is not always optimal among all compression methods it is replaced with arithmetic coding or asymmetric numeral systems if better compression ratio is required.")]
        public IActionResult HuffmansAlgorithm([FromQuery] string msg)
        {
            Huffman huff = new Huffman(msg);
            return Ok(huff.codes);
        }

        [HttpPost("FractionalKnapsackProblem")]
        [SwaggerOperation(description: "values = { 4, 9, 12, 11, 6, 5 }, weights = { 1, 2, 10, 4, 3, 5 }, capacity = 12")]
        public IActionResult FractionalKnapsackProblem(FractionalKnapsackProblemRequest request)
        {
            return Ok(KnapsackSolver
                        .SolveFractionalKnapsack(request.values, request.weights, request.capacity)
                        .ToString());
        }
    }
}