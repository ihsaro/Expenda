using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.MonthlyBudgetManager.Models.Response;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.MonthlyBudgetManager.Queries;

public class ListMonthlyBudgetsQuery : IRequest<TransactionResult<IEnumerable<MonthlyBudgetResponse>>> { }

public class ListMonthlyBudgetsQueryHandler : IRequestHandler<ListMonthlyBudgetsQuery, TransactionResult<IEnumerable<MonthlyBudgetResponse>>>
{
    private readonly IApplicationSessionManager _session;
    private readonly IMonthlyBudgetRepository _repository;
    private readonly IMapper _mapper;

    public ListMonthlyBudgetsQueryHandler(IApplicationSessionManager session, IMonthlyBudgetRepository repository, IMapper mapper)
    {
        _session = session;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransactionResult<IEnumerable<MonthlyBudgetResponse>>> Handle(ListMonthlyBudgetsQuery request, CancellationToken token)
    {
        var entities = await _repository.GetForUser(_session.CurrentUser.Id, token);
        return new TransactionResult<IEnumerable<MonthlyBudgetResponse>>(_mapper.Map<IEnumerable<MonthlyBudgetResponse>>(entities));
    }
}