using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerApplication _application;

    public CustomerController(ICustomerApplication application)
        => _application = application;

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var result = await _application.StartRegistrationCustomerAsync(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var result = await _application.UpdateRegistrationCustomerAsync(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [Authorize]
    [HttpGet("list")]
    public async Task<IActionResult> ListCustomers(CancellationToken cancellationToken)
    {
        var result = await _application.GetAll(cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }
}

