using Microsoft.Extensions.Localization;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Localization.Models;

namespace Expenda.Infrastructure.Localization;

internal abstract class LocalizationMessengerBase<T> : ILocalizationMessengerBase
{
    private readonly IStringLocalizer<T> _localizer;

    public LocalizationMessengerBase(IStringLocalizer<T> localizer) =>
        _localizer = localizer;

    public BaseMessage GetMessage(string code)
    {
        var localizedString = _localizer[code];
        return new BaseMessage(code, localizedString.Value);
    }
}
