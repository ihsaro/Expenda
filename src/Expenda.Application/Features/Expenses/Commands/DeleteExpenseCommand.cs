using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.Expenses.Commands;

public class DeleteExpenseCommand : IRequest<TransactionResult<bool>>
{
    public int Id { get; set; }
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
        var entity = await _repository.GetById(command.Id, token);

        if (entity is null || entity.Owner.Id != _session.CurrentUser.Id)
        {
            return new TransactionResult<bool>(false)
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }

        _repository.Delete(entity, token);
        
        var operation = await _repository.Commit(token);

        return new TransactionResult<bool>(operation == 1);
    }
}