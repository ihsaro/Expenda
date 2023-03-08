using Microsoft.AspNetCore.Mvc;

using Expenda.Web.Routes.Configuration;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;

namespace Expenda.Web.Routes.V1;

public sealed class AuthenticationRoutes : IRoute
{
    public void ConfigureRoutes(WebApplication app)
    {
        app
            .MapPost("api/v1/authentication/register", Register)
            .AllowAnonymous();
        
        app
            .MapPost("api/v1/authentication/login", Login)
            .AllowAnonymous();
    }

    private async Task<IResult> Register([FromBody] RegistrationRequest request, [FromServices] IAuthenticationService service, CancellationToken token = default)
    {
        var result = await service.Register(request, token);
        return result.Success && result.ResultObject is not null ? Results.Created($"api/v1/authentication/register/{result.ResultObject.Id}", result) : Results.BadRequest(result);
    }

    private async Task<IResult> Login([FromBody] LoginRequest request, [FromServices] IAuthenticationService service, CancellationToken token = default)
    {
        var result = await service.Login(request, token);
        return result.Success ? Results.Ok(result) : Results.BadRequest(result);
    }
}
