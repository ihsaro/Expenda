using Expenda.Application.Architecture.Security;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IApplicationTokenManager _tokenManager;
    
    public AuthenticationController(IAuthenticationService authenticationService, IApplicationTokenManager tokenManager)
    {
        _authenticationService = authenticationService;
        _tokenManager = tokenManager;
    }
    
    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromBody] VerifyUserCredentialRequest request, CancellationToken token = default)
    {
        var result = await _authenticationService.VerifyUserCredential(request, token);

        if (!result) return Unauthorized();
        
        var jwt = _tokenManager.GenerateAndGetToken(request.Username);

        HttpContext.Response.Cookies.Append("at", jwt, new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax
        });

        return Ok();

    }
    
    [HttpPost("register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request, CancellationToken token = default)
    {
        var result = await _authenticationService.RegisterUser(request, token);
        return result is { Success: true, ResultObject: true } ? Ok() : BadRequest(result);
    }
}