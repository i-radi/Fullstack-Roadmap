using Blogify.Models;
using Blogify.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogify.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
	private readonly ILogger<PostController> _logger;
	private readonly IPostService _postDbService;

	public PostController(ILogger<PostController> logger, IPostService dbService)
	{
		_postDbService = dbService;
		_logger = logger;
	}

	[HttpGet]
	public IEnumerable<Post> Get()
	{
		return _postDbService.FindAll();
	}

	[HttpGet("{id}", Name = "FindOne")]
	public ActionResult<Post> Get(int id)
	{
		var result = _postDbService.FindOne(id);
		if (result != default)
			return Ok(result);
		else
			return NotFound();
	}

	[HttpPost]
	public ActionResult<Post> Insert(Post dto)
	{
		var id = _postDbService.Insert(dto);
		if (id != default)
			return CreatedAtRoute("FindOne", new { id = id }, dto);
		else
			return BadRequest();
	}

	[HttpPut]
	public ActionResult<Post> Update(Post dto)
	{
		var result = _postDbService.Update(dto);
		if (result)
			return NoContent();
		else
			return NotFound();
	}

	[HttpDelete("{id}")]
	public ActionResult<Post> Delete(int id)
	{
		var result = _postDbService.Delete(id);
		if (result)
			return NoContent();
		else
			return NotFound();
	}
}