using System.Security.Claims;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserApplication _application;

    public UserController(IUserApplication application)
        => _application = application;
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _application.AuthLogin(request, cancellationToken);

        if (!result.Success)
            return StatusCode(result.StatusCode, new { error = result.Error });

        return StatusCode(result.StatusCode, new { data = result.Data });
    }

    [HttpGet("ping")]
    public IActionResult GetCurrentUser()
    {
        return Ok(new
        {
            message = "pong"
        });
    }

    //[HttpGet("me")]
    //[Authorize]
    //public IActionResult GetCurrentUser()
    //{
    //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //    var email = User.FindFirst(ClaimTypes.Name)?.Value;

    //    return Ok(new
    //    {
    //        message = "Token is valid!",
    //        userId,
    //        email
    //    });
    //}

    //[HttpGet("me2")]
    //[Authorize]
    //public IActionResult GetCurrentUser2()
    //{
    //    if (!User.Identity.IsAuthenticated)
    //        return Unauthorized("Not authenticated");

    //    var token = HttpContext.Request.Headers["Authorization"].ToString();

    //    return Ok(new
    //    {
    //        tokenReceived = token,
    //        claims = User.Claims.Select(c => new { c.Type, c.Value })
    //    });
    //}
}

