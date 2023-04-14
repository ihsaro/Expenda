using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] VerifyUserCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);

        if (!result.Success || result.ResultObject is null) return Unauthorized();
        
        HttpContext.Response.Cookies.Append("at", result.ResultObject.AccessToken, new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax
        });

        return Ok();

    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);
        return result is { Success: true } ? Ok(result.ResultObject) : BadRequest(result);
    }
}