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
        var accessToken = context.Request.Cookies.FirstOrDefault(x => x.Key.Equals("at")).Value;

        switch (context.Request.Path.HasValue)
        {
            case true when !context.Request.Path.Value.Equals("/") && !context.Request.Path.Value.StartsWith("/api") && !_tokenManager.IsTokenValid(accessToken):
                context.Response.Redirect("/");
                return;
            case true when !context.Request.Path.Value.StartsWith("/app") && !context.Request.Path.Value.StartsWith("/api") && _tokenManager.IsTokenValid(accessToken):
                context.Response.Redirect("/app");
                return;
            default:
                await _next(context);
                break;
        }
    }
}