using Expenda.Application.Architecture.Localization;
using Microsoft.Extensions.Localization;

namespace Expenda.Infrastructure.Localization;

internal class MonthlyBudgetMessenger : MessengerBase<AuthenticationMessenger>, IAuthenticationMessenger
{
    public MonthlyBudgetMessenger(IStringLocalizer<AuthenticationMessenger> localizer) : base(localizer) { }
}