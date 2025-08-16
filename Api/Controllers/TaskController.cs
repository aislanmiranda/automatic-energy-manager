using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskApplication _application;

    public TaskController(ITaskApplication application)
        => _application = application;

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] List<TaskRequest> request, CancellationToken cancellationToken)
    {
        var result = await _application.CreateTask(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetMyTasks(Guid equipamentId, CancellationToken cancellationToken)
    {
        var result = await _application.GetTasks(equipamentId, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteTask([FromQuery] string taskJobId, Guid equipamentId, CancellationToken cancellationToken)
    {
        var result = await _application.DeleteTask(taskJobId, equipamentId, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpPost("sinal/onoff")]
    public async Task<IActionResult> SendSinalOnOffFreezer([FromBody] OnOffRequest request, CancellationToken cancellationToken)
    {
        var result = await _application.SendSinalOnOffFreezer(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }
}

