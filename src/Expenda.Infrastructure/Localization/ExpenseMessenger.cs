using Microsoft.Extensions.Localization;
using Expenda.Application.Architecture.Localization;

namespace Expenda.Infrastructure.Localization;

internal class ExpenseMessenger : MessengerBase<ExpenseMessenger>, IExpenseMessenger
{
    public ExpenseMessenger(IStringLocalizer<ExpenseMessenger> localizer) : base(localizer) { }
}
