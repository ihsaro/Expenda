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
    private readonly IExpenseRepository _repository;
    private readonly IApplicationSessionManager _session;
    private readonly IExpenseMessenger _messenger;

    public DeleteExpenseCommandHandler(IExpenseRepository repository, IApplicationSessionManager session, IExpenseMessenger messenger)
    {
        _repository = repository;
        _session = session;
        _messenger = messenger;
    }

    public async Task<TransactionResult<bool>> Handle(DeleteExpenseCommand command, CancellationToken token)
    {
        var entity = await _repository.GetByIdAsync(command.Id, token);

        if (entity is null || entity.OwnerId != _session.CurrentUserId)
        {
            return new TransactionResult<bool>(false)
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }

        _repository.Delete(entity);
        
        var operation = await _repository.CommitAsync(token);

        return new TransactionResult<bool>(operation == 1);
    }
}