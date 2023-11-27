using Expenda.Application.Architecture.Localization;
using Microsoft.Extensions.Localization;

namespace Expenda.Infrastructure.Localization;

internal class MonthlyBudgetLocalizationMessenger : LocalizationMessengerBase<MonthlyBudgetLocalizationMessenger>, IMonthlyBudgetLocalizationMessenger
{
    public MonthlyBudgetLocalizationMessenger(IStringLocalizer<MonthlyBudgetLocalizationMessenger> localizer) : base(localizer) { }
}