using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.ExpenseManager.Models.Response;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.ExpenseManager.Queries;

public class GetExpenseQuery : IRequest<TransactionResult<ExpenseResponse>>
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
}

public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, TransactionResult<ExpenseResponse>>
{
    private readonly IApplicationSessionManager _session;
    private readonly IExpenseMessenger _messenger;
    private readonly IExpenseRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseQueryHandler(IApplicationSessionManager session, IExpenseMessenger messenger, IExpenseRepository repository, IMapper mapper)
    {
        _session = session;
        _messenger = messenger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransactionResult<ExpenseResponse>> Handle(GetExpenseQuery query, CancellationToken token)
    {
        var entity = await _repository.GetByIdAsync(query.Id, token);

        if (entity is null || entity.OwnerId != _session.CurrentUserId)
        {
            return new TransactionResult<ExpenseResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }
        
        return new TransactionResult<ExpenseResponse>(_mapper.Map<ExpenseResponse>(entity));
    }
}
