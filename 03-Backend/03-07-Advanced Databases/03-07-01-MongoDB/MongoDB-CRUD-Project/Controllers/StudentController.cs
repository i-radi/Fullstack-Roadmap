using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD_Project.Models;
using MongoDB_CRUD_Project.Services;

namespace MongoDB_CRUD_Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentsController(StudentService studentService) =>
        _studentService = studentService;

    [HttpGet]
    public async Task<List<Student>> Get() =>
        await _studentService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Student>> Get(string id)
    {
        var student = await _studentService.GetAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        return student;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Student newstudent)
    {
        await _studentService.CreateAsync(newstudent);

        return CreatedAtAction(nameof(Get), new { id = newstudent.Id }, newstudent);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Student updatedstudent)
    {
        var student = await _studentService.GetAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        updatedstudent.Id = student.Id;

        await _studentService.UpdateAsync(id, updatedstudent);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var student = await _studentService.GetAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        await _studentService.RemoveAsync(id);

        return NoContent();
    }
}