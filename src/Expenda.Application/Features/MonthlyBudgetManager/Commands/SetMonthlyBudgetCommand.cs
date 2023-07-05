using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.MonthlyBudgetManager.Models.Response;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.MonthlyBudgetManager.Commands;

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
    private readonly IMonthlyBudgetRepository _repository;
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;
    private readonly IMonthlyBudgetMessenger _messenger;

    public SetMonthlyBudgetCommandHandler(IMonthlyBudgetRepository repository, IMapper mapper, IApplicationSessionManager session, IMonthlyBudgetMessenger messenger)
    {
        _repository = repository;
        _mapper = mapper;
        _session = session;
        _messenger = messenger;
    }

    public async Task<TransactionResult<MonthlyBudgetResponse>> Handle(SetMonthlyBudgetCommand command, CancellationToken token)
    {
        var entity = await _repository.GetForUserByMonthAndYear(_session.CurrentUser.Id, command.Month, command.Year, token);

        if (entity is not null && entity.Owner.Id != _session.CurrentUser.Id)
        {
            return new TransactionResult<MonthlyBudgetResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("MONTHLY_BUDGET_DOES_NOT_BELONG_TO_USER")));
        }

        if (entity is null)
            _repository.Create(_mapper.Map<MonthlyBudget>(entity, opt => opt.Items["Owner"] = _session.CurrentUser));
        else
            entity.Budget = command.Budget;

        await _repository.Commit(token);
        return new TransactionResult<MonthlyBudgetResponse>(_mapper.Map<MonthlyBudgetResponse>(entity));
    }
}