using Microsoft.Extensions.Localization;
using Expenda.Application.Architecture.Localization;

namespace Expenda.Infrastructure.Localization;

internal class AuthenticationMessenger : MessengerBase<AuthenticationMessenger>, IAuthenticationMessenger
{
    public AuthenticationMessenger(IStringLocalizer<AuthenticationMessenger> localizer) : base(localizer) { }
}
