using System.Text.Json.Serialization;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.UserManager.Queries;

public class GetUserDataMetricsQuery : IRequest<TransactionResult<UserDataMetricsResponse>>
{
}

public record UserDataMetricsResponse
(
    [property: JsonPropertyName("total_amount_spent")] float TotalAmountSpent,
    [property: JsonPropertyName("current_monthly_budget")] float CurrentMonthlyBudget
);

public class GetUserDataMetricsQueryHandler : IRequestHandler<GetUserDataMetricsQuery, TransactionResult<UserDataMetricsResponse>>
{
    private readonly IApplicationSessionManager _session;
    private readonly IUserDataRepository _repository;

    public GetUserDataMetricsQueryHandler(IApplicationSessionManager session, IUserDataRepository repository)
    {
        _session = session;
        _repository = repository;
    }

    public async Task<TransactionResult<UserDataMetricsResponse>> Handle(GetUserDataMetricsQuery request, CancellationToken cancellationToken)
    {
        var (totalAmountSpent, currentMonthlyBudget) = await _repository.GetUserDataMetrics(cancellationToken);
        return new TransactionResult<UserDataMetricsResponse>(new UserDataMetricsResponse(totalAmountSpent, currentMonthlyBudget));
    }
}
