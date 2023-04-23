using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.Expenses.Commands;

public class UpdateExpenseCommand : CreateExpenseCommand
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, TransactionResult<ExpenseResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;
    private readonly IExpenseMessenger _messenger;
    private readonly IExpenseRepository _repository;

    public UpdateExpenseCommandHandler(IMapper mapper, IApplicationSessionManager session, IExpenseMessenger messenger, IExpenseRepository repository)
    {
        _mapper = mapper;
        _session = session;
        _messenger = messenger;
        _repository = repository;
    }

    public async Task<TransactionResult<ExpenseResponse>> Handle(UpdateExpenseCommand command, CancellationToken token)
    {
        var entity = await _repository.GetById(command.Id, token);

        if (entity is null || entity.Owner.Id != _session.CurrentUser.Id)
        {
            return new TransactionResult<ExpenseResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }

        _repository.Update(entity, token);
        await _repository.Commit(token);

        return new TransactionResult<ExpenseResponse>(_mapper.Map<ExpenseResponse>(entity));
    }
}