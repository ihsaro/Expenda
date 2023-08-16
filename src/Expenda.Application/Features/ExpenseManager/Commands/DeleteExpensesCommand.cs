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
    private readonly IExpenseRepository _repository;
    private readonly IApplicationSessionManager _session;
    private readonly IExpenseMessenger _messenger;

    public DeleteExpensesCommandHandler(IExpenseRepository repository, IApplicationSessionManager session, IExpenseMessenger messenger)
    {
        _repository = repository;
        _session = session;
        _messenger = messenger;
    }

    public async Task<TransactionResult<bool>> Handle(DeleteExpensesCommand command, CancellationToken token)
    {
        var entities = await _repository.GetExpensesByIds(command.Ids, token);
        entities = entities.ToList();

        if (entities.Any(x => x.Owner.Id != _session.CurrentUser.Id))
        {
            return new TransactionResult<bool>(false).AddErrorMessage(new ErrorMessage(_messenger.GetMessage("ONE_OR_MORE_EXPENSES_DO_NOT_EXIST")));
        }
        
        _repository.BatchDelete(entities);
        await _repository.CommitAsync(token);

        return new TransactionResult<bool>(true);
    }
}