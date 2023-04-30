using Expenda.Application.Architecture.Localization;
using Microsoft.Extensions.Localization;

namespace Expenda.Infrastructure.Localization;

internal class MonthlyBudgetMessenger : MessengerBase<MonthlyBudgetMessenger>, IMonthlyBudgetMessenger
{
    public MonthlyBudgetMessenger(IStringLocalizer<MonthlyBudgetMessenger> localizer) : base(localizer) { }
}