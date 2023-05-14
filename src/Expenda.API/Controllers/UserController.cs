using Expenda.Application.Features.UserManager.Commands;
using Expenda.Application.Features.UserManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] VerifyUserCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);
        return !result.Success || result.ResultObject is null ? Unauthorized() : Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);
        return result is { Success: true } ? Ok(result.ResultObject) : BadRequest(result);
    }

    [HttpGet("metrics")]
    [Authorize]
    public async Task<IActionResult> GetUserDataMetrics(CancellationToken token = default)
    {
        return Ok(await _mediator.Send(new GetUserDataMetricsQuery(), token));
    }
}