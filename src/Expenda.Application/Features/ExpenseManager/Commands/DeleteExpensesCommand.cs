using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.ExpenseManager.Commands;

public class DeleteExpensesCommand : IRequest<TransactionResult<bool>>
{
    public IEnumerable<int> Ids { get; set; } = null!;
}

public class DeleteExpensesCommandHandler : IRequestHandler<DeleteExpensesCommand, TransactionResult<bool>>
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IApplicationSessionManager _applicationSessionManager;
    private readonly IExpenseLocalizationMessenger _expenseLocalizationMessenger;

    public DeleteExpensesCommandHandler(IExpenseRepository expenseRepository,
                                        IApplicationSessionManager applicationSessionManager,
                                        IExpenseLocalizationMessenger expenseLocalizationMessenger)
    {
        _expenseRepository = expenseRepository;
        _applicationSessionManager = applicationSessionManager;
        _expenseLocalizationMessenger = expenseLocalizationMessenger;
    }

    public async Task<TransactionResult<bool>> Handle(DeleteExpensesCommand command, CancellationToken token)
    {
        var entities = await _expenseRepository.GetExpensesByIds(command.Ids, token);

        if (entities.Any(x => x.OwnerId != _applicationSessionManager.CurrentUserId))
        {
            return new TransactionResult<bool>(false)
                .AddErrorMessage(new ErrorMessage(_expenseLocalizationMessenger.GetMessage("ONE_OR_MORE_EXPENSES_DO_NOT_EXIST")));
        }
        
        _expenseRepository.BatchDelete(entities);
        await _expenseRepository.CommitAsync(token);

        return new TransactionResult<bool>(true);
    }
}