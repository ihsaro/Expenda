using Microsoft.AspNetCore.Mvc;

using Expenda.Web.Routes.Configuration;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;
using Expenda.Application.Architecture.Security;

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
        var result = await service.RegisterUser(request, token);
        return result.Success && result.ResultObject ? Results.Ok() : Results.BadRequest(result);
    }

    private async Task<IResult> Login([FromBody] VerifyUserCredentialRequest request, [FromServices] IAuthenticationService service, [FromServices] IApplicationTokenManager tokenManager, [FromServices] HttpContext context, CancellationToken token = default)
    {
        var result = await service.VerifyUserCredential(request, token);

        if (result)
        {
            var jwt = tokenManager.GenerateAndGetToken(request.Username);

            context.Response.Cookies.Append("at", jwt, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            });

            return Results.Ok();
        }

        return Results.Unauthorized();
    }
}
