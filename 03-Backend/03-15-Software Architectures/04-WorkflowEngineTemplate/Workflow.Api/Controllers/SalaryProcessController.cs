using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OptimaJet.Workflow.Core.Runtime;

namespace Workflow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SalaryProcessController : ControllerBase
{
    [HttpGet("CreateWorkflowInstance")]
    public IActionResult CreateInstance(string schemeCode)
    {
        var processId = Guid.NewGuid();
        try
        {
            WorkflowInit.Runtime.CreateInstance(schemeCode, processId);
            return Ok($"CreateInstance - OK., {processId}");
        }
        catch (Exception ex)
        {
            return BadRequest($"CreateInstance - Exception: {ex.Message}");
        }
    }

    [HttpGet("GetAvailableCommands")]
    public IActionResult GetAvailableCommands(Guid processId, string userId)
    {
        var commands = WorkflowInit.Runtime.GetAvailableCommands(processId, userId);

        if (!commands.Any())
        {
            return NotFound("Not found!");
        }

        var result = commands.Select(
            c => new { c.CommandName, c.LocalizedName });

        return Ok(result);
    }

    [HttpGet("ExecuteCommand")]
    public IActionResult ExecuteCommand(Guid processId, string userId, string commandName)
    {
        commandName = commandName.Trim().ToLower();

        WorkflowCommand command = WorkflowInit.Runtime
                .GetAvailableCommands(processId, userId)
                .FirstOrDefault(c => c.CommandName.Trim().ToLower() == commandName)!;

        if (command is null)
            return NotFound("The command isn't found.");

        WorkflowInit.Runtime.ExecuteCommand(command, userId, userId);

        return Ok($"CreateInstance - OK., {processId}");
    }

    [HttpGet("GetAvailableState")]
    public IActionResult GetAvailableState(Guid processId)
    {
        var states = WorkflowInit.Runtime
            .GetAvailableStateToSet(processId, Thread.CurrentThread.CurrentCulture);

        if (!states.Any())
        {
            return NotFound("Not found!");
        }

        var result = states.Select(c => new { c.Name });

        return Ok(result);
    }

    [HttpGet("SetState")]
    public IActionResult SetState(Guid processId, string userId, string stateName)
    {
        stateName = stateName.Trim().ToLower();
        if (string.IsNullOrEmpty(stateName))
            return BadRequest("invalid state name!");

        WorkflowState state = WorkflowInit.Runtime
                .GetAvailableStateToSet(processId, Thread.CurrentThread.CurrentCulture)
                .Where(c => c.Name.Trim().ToLower() == stateName).FirstOrDefault()!;
        if (state is null)
            return NotFound("The state isn't found.");

        WorkflowInit.Runtime.SetState(new SetStateParams(processId, state.Name));

        return Ok($"SetState - OK. , {processId}");

    }

    [HttpGet("DeleteProcess")]
    public IActionResult DeleteProcess(Guid processId)
    {
        var states = WorkflowInit.Runtime
            .GetAvailableStateToSet(processId, Thread.CurrentThread.CurrentCulture);

        if (!states.Any())
        {
            return NotFound("Not found!");
        }

        WorkflowInit.Runtime.DeleteInstance(processId);
        
        return Ok($"DeleteProcess - OK. , {processId}");
    }
}
