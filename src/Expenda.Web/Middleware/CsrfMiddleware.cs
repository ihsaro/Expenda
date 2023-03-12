using Microsoft.AspNetCore.Antiforgery;

namespace Expenda.Web.Middleware;

public class CsrfMiddleware
{
    private readonly IAntiforgery _antiforgery;
    private readonly RequestDelegate _next;

    private static readonly string[] CsrfInclusionUrls =
    {
        "/"
    };

    public CsrfMiddleware(IAntiforgery antiforgery, RequestDelegate next)
    {
        _antiforgery = antiforgery;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestPath = context.Request.Path.Value;

        if (context.Request.Method.Equals(HttpMethod.Get.Method) && CsrfInclusionUrls.Contains(requestPath))
        {
            var tokenSet = _antiforgery.GetTokens(context);

            context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
                new CookieOptions { HttpOnly = false });
        }
        
        await _next(context);
    }
}