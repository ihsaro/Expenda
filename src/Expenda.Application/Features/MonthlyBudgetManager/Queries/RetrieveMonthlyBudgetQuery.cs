using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.MonthlyBudgetManager.Models.Response;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.MonthlyBudgetManager.Queries;

public class RetrieveMonthlyBudgetQuery : IRequest<TransactionResult<MonthlyBudgetResponse>>
{
    public int Month { get; set; }
    public int Year { get; set; }
}

public class RetrieveMonthlyBudgetQueryHandler : IRequestHandler<RetrieveMonthlyBudgetQuery, TransactionResult<MonthlyBudgetResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;
    private readonly IMonthlyBudgetRepository _repository;
    private readonly IMonthlyBudgetMessenger _messenger;

    public RetrieveMonthlyBudgetQueryHandler(IMapper mapper, IApplicationSessionManager session, IMonthlyBudgetRepository repository, IMonthlyBudgetMessenger messenger)
    {
        _mapper = mapper;
        _session = session;
        _repository = repository;
        _messenger = messenger;
    }

    public async Task<TransactionResult<MonthlyBudgetResponse>> Handle(RetrieveMonthlyBudgetQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetForUserByMonthAndYear(_session.CurrentUser.Id, request.Month, request.Year, cancellationToken);

        if (entity is null)
        {
            return new TransactionResult<MonthlyBudgetResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("MONTHLY_BUDGET_DOES_NOT_EXIST")));
        }
        
        return new TransactionResult<MonthlyBudgetResponse>(_mapper.Map<MonthlyBudgetResponse>(entity));
    }
}