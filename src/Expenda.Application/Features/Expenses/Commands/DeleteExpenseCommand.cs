using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.Expenses.Commands;

public class DeleteExpenseCommand : IRequest<TransactionResult<DeleteExpenseCommandResponse>>
{
    public required IEnumerable<int> ids { get; set; }
}

public class DeleteExpenseCommandResponse
{
    
}

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, TransactionResult<DeleteExpenseCommandResponse>>
{
    private readonly IExpenseRepository _repository;

    public DeleteExpenseCommandHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransactionResult<DeleteExpenseCommandResponse>> Handle(DeleteExpenseCommand command, CancellationToken token)
    {
        foreach (var id in command.ids)
        {
            await _repository.Delete(id, token);
        }

        var x = await _repository.Commit(token);

        if (x != command.ids.Count())
        {
            // To be handled
        }
        return new TransactionResult<DeleteExpenseCommandResponse>();
    }
}