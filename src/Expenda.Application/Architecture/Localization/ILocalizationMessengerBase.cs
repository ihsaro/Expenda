using Expenda.Application.Architecture.Localization.Models;

namespace Expenda.Application.Architecture.Localization;

public interface ILocalizationMessengerBase
{
    BaseMessage GetMessage(string code);
}
