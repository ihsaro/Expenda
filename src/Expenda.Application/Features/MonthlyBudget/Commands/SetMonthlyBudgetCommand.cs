using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using MediatR;

namespace Expenda.Application.Features.MonthlyBudget.Commands;

public class SetMonthlyBudgetCommand : IRequest<TransactionResult<MonthlyBudgetResponse>>
{
    [JsonPropertyName("month")]
    public int Month { get; set; }
    
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("budget")]
    public int Budget { get; set; }
}

public class SetMonthlyBudgetCommandHandler : IRequestHandler<SetMonthlyBudgetCommand, TransactionResult<MonthlyBudgetResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;

    public SetMonthlyBudgetCommandHandler(IMapper mapper, IApplicationSessionManager session)
    {
        _mapper = mapper;
        _session = session;
    }

    public Task<TransactionResult<MonthlyBudgetResponse>> Handle(SetMonthlyBudgetCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}