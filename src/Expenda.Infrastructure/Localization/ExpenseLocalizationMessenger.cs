using Microsoft.Extensions.Localization;
using Expenda.Application.Architecture.Localization;

namespace Expenda.Infrastructure.Localization;

internal class ExpenseLocalizationMessenger : LocalizationMessengerBase<ExpenseLocalizationMessenger>, IExpenseLocalizationMessenger
{
    public ExpenseLocalizationMessenger(IStringLocalizer<ExpenseLocalizationMessenger> localizer) : base(localizer) { }
}
