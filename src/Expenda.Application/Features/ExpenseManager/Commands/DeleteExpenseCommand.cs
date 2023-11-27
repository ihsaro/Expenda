using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.ExpenseManager.Commands;

public class DeleteExpenseCommand : IRequest<TransactionResult<bool>>
{
    public int Id { get; init; }
}

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, TransactionResult<bool>>
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IApplicationSessionManager _applicationSessionManager;
    private readonly IExpenseLocalizationMessenger _expenseLocalizationMessenger;

    public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository,
                                       IApplicationSessionManager applicationSessionMessenger,
                                       IExpenseLocalizationMessenger expenseLocalizationMessenger)
    {
        _expenseRepository = expenseRepository;
        _applicationSessionManager = applicationSessionMessenger;
        _expenseLocalizationMessenger = expenseLocalizationMessenger;
    }

    public async Task<TransactionResult<bool>> Handle(DeleteExpenseCommand command, CancellationToken token)
    {
        var entity = await _expenseRepository.GetByIdAsync(command.Id, token);

        if (entity is null || entity.OwnerId != _applicationSessionManager.CurrentUserId)
        {
            return new TransactionResult<bool>(false)
                .AddErrorMessage(new ErrorMessage(_expenseLocalizationMessenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }

        _expenseRepository.Delete(entity);
        
        var operation = await _expenseRepository.CommitAsync(token);

        return new TransactionResult<bool>(operation == 1);
    }
}