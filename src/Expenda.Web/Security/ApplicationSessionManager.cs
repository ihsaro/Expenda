using System.Net;
using System.Security.Claims;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;

namespace Expenda.Web.Security;

internal class ApplicationSessionManager : IApplicationSessionManager
{
    public ApplicationUser CurrentUser { get; }

    public ApplicationSessionManager(IHttpContextAccessor accessor, IApplicationUserManager userManager)
    {
        var userIdIdentifier = accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdIdentifier is null || !int.TryParse(userIdIdentifier.Value, out var id))
            throw new HttpRequestException(null, null, HttpStatusCode.Forbidden);

        var user = userManager.FindByIdAsync(id).Result ?? throw new HttpRequestException(null, null, HttpStatusCode.Forbidden);
        CurrentUser = user;
    }
}
