using System.Security.Claims;
using Expenda.Application.Architecture.Security;

namespace Expenda.Web.Middleware;

public class RouteProtectionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IApplicationTokenManager _tokenManager;

    public RouteProtectionMiddleware(RequestDelegate next, IApplicationTokenManager tokenManager)
    {
        _next = next;
        _tokenManager = tokenManager;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var accessToken = context.Request.Cookies.Where(x => x.Key.Equals("at")).FirstOrDefault().Value;

        System.Console.WriteLine(_tokenManager.IsTokenValid(accessToken));

        if (context.Request.Path.HasValue && !context.Request.Path.Value.Equals("/") && !context.Request.Path.Value.StartsWith("/api") && !_tokenManager.IsTokenValid(accessToken))
        {
            context.Response.Redirect("/");
            return;
        }
        else if (context.Request.Path.HasValue && !context.Request.Path.Value.StartsWith("/app") && !context.Request.Path.Value.StartsWith("/api") && _tokenManager.IsTokenValid(accessToken))
        {
            context.Response.Redirect("/app");
            return;
        }

        await _next(context);
    }
}