using Learnify.API.Models;
using Learnify.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Learnify.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
	private readonly ILogger<CourseController> _logger;
	private readonly ICouchRepository _couchRepository;
	public CourseController(ILogger<CourseController> logger, ICouchRepository couchRepository)
	{
		_logger = logger;
		_couchRepository = couchRepository;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(string id)
	{
		var result = await _couchRepository.GetDocumentAsync(id);
		if (result.IsSuccess)
		{
			var sResult = JsonConvert.DeserializeObject<EnrollInfo>(result.SuccessContentObject);
			return new OkObjectResult(sResult);
		}
		return new NotFoundObjectResult("NotFound");
	}

	[HttpPost]
	public async Task<IActionResult> PostAsync([FromBody] EnrollCourse enrollCourse)
	{
		enrollCourse.EnrolledOn = DateTime.Now;
		var result = await _couchRepository.PostDocumentAsync(enrollCourse);
		if (result.IsSuccess)
		{
			var sResult = JsonConvert.DeserializeObject<SavedResult>(result.SuccessContentObject);
			return new CreatedResult("Success", sResult);
		}

		return new UnprocessableEntityObjectResult(result.FailedReason);
	}

	[HttpPut]
	public async Task<IActionResult> PutAsync([FromBody] UpdateEnroll enrollCourse)
	{
		var httpClientResponse = await _couchRepository.GetDocumentAsync(enrollCourse.Id);

		if (httpClientResponse.IsSuccess)
		{
			EnrollInfo existingInfo = JsonConvert.DeserializeObject<EnrollInfo>(httpClientResponse.SuccessContentObject);
			enrollCourse.Rev = existingInfo.Rev;
			enrollCourse.Name = String.IsNullOrEmpty(enrollCourse.Name) ? existingInfo.Name : enrollCourse.Name;
			enrollCourse.CourseName = String.IsNullOrEmpty(enrollCourse.CourseName) ? existingInfo.CourseName : enrollCourse.CourseName;
			enrollCourse.EmailAddress = String.IsNullOrEmpty(enrollCourse.EmailAddress) ? existingInfo.EmailAddress : enrollCourse.EmailAddress;
			enrollCourse.EnrolledOn = enrollCourse.EnrolledOn == DateTime.MinValue ? existingInfo.EnrolledOn : enrollCourse.EnrolledOn;
			enrollCourse.UpdatedOn = enrollCourse.UpdatedOn == DateTime.MinValue ? DateTime.Now : enrollCourse.UpdatedOn;

			var result = await _couchRepository.PutDocumentAsync(enrollCourse);
			if (httpClientResponse.IsSuccess)
			{
				var sResult = JsonConvert.DeserializeObject<SavedResult>(result.SuccessContentObject);
				return new CreatedResult("Success", sResult);
			}
			return new UnprocessableEntityObjectResult(result.FailedReason);
		}

		return new UnprocessableEntityObjectResult(httpClientResponse.FailedReason);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAsync(string id)
	{
		var httpClientResponse = await _couchRepository.GetDocumentAsync(id);

		if (httpClientResponse.IsSuccess)
		{
			EnrollInfo sResult = JsonConvert.DeserializeObject<EnrollInfo>(httpClientResponse.SuccessContentObject);
			httpClientResponse = await _couchRepository.DeleteDocumentAsync(id, sResult.Rev);
			if (httpClientResponse.IsSuccess)
			{
				return new OkObjectResult("Success");
			}
			return new NotFoundObjectResult("Failed to delete the document");
		}

		return new NotFoundObjectResult("Document not exists.");
	}
}