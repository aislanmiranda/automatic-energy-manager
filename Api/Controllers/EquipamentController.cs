using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class EquipamentController : ControllerBase
{
    private readonly IEquipamentApplication _application;

    public EquipamentController(IEquipamentApplication application)
        => _application = application;
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateEquipament([FromBody]EquipamentCreateRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _application.CreateEquipament(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateEquipament([FromBody] EquipamentUpdateRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _application.UpdateEquipament(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteEquipament([FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _application.DeleteEquipament(id, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpGet("ListByCustomer")]
    public async Task<IActionResult> ListByCustomerId([FromQuery] Guid customerId,
        CancellationToken cancellationToken)
    {
        var result = await _application.ListEquipamentByCustomer(customerId, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }
}

