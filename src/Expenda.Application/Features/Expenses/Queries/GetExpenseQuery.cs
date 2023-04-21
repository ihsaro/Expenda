using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using MediatR;

namespace Expenda.Application.Features.Expenses.Queries;

public class GetExpenseQuery : IRequest<TransactionResult<ExpenseResponse>>
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
}

public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, TransactionResult<ExpenseResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public GetExpenseQueryHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public Task<TransactionResult<ExpenseResponse>> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
