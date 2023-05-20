using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.UserManager.Queries;

public class GetUserDataMetricsQuery : IRequest<TransactionResult<GetUserDataMetricsResponse>>
{
}

public record GetUserDataMetricsResponse
(
    [property: JsonPropertyName("total_amount_spent")] float TotalAmountSpent,
    [property: JsonPropertyName("last_item_purchased")] string LastItemPurchased,
    [property: JsonPropertyName("last_item_purchased_quantity")] int LastItemPurchasedQuantity,
    [property: JsonPropertyName("last_item_purchased_total_price")] float LastItemPurchasedTotalPrice
);

public class GetUserDataMetricsQueryHandler : IRequestHandler<GetUserDataMetricsQuery, TransactionResult<GetUserDataMetricsResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;
    private readonly IUserDataRepository _repository;

    public GetUserDataMetricsQueryHandler(IMapper mapper, IApplicationSessionManager session, IUserDataRepository repository)
    {
        _mapper = mapper;
        _session = session;
        _repository = repository;
    }

    public async Task<TransactionResult<GetUserDataMetricsResponse>> Handle(GetUserDataMetricsQuery request, CancellationToken token)
    {
        var metrics = await _repository.GetUserDataMetrics(_session.CurrentUser.Id, token);
        return new TransactionResult<GetUserDataMetricsResponse>(_mapper.Map<GetUserDataMetricsResponse>(metrics));
    }
}
