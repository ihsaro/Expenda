namespace Expenda.Web.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseAntiForgery(this IApplicationBuilder builder)
        => builder.UseMiddleware<CsrfMiddleware>();

    public static IApplicationBuilder UseRouteProtection(this IApplicationBuilder builder)
        => builder.UseMiddleware<RouteProtectionMiddleware>();
}