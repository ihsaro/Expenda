using Microsoft.Extensions.Localization;
using Expenda.Application.Architecture.Localization;

namespace Expenda.Infrastructure.Localization;

internal class AuthenticationLocalizationMessenger : LocalizationMessengerBase<AuthenticationLocalizationMessenger>, IAuthenticationLocalizationMessenger
{
    public AuthenticationLocalizationMessenger(IStringLocalizer<AuthenticationLocalizationMessenger> localizer) : base(localizer) { }
}
