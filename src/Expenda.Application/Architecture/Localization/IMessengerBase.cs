using Expenda.Application.Architecture.Localization.Models;

namespace Expenda.Application.Architecture.Localization;

public interface IMessengerBase
{
    BaseMessage GetMessage(string code);
}
