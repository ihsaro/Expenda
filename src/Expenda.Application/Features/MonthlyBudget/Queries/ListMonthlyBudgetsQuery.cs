using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using MediatR;

namespace Expenda.Application.Features.MonthlyBudget.Queries;

public class ListMonthlyBudgetsQuery : IRequest<TransactionResult<ListMonthlyBudgetsQueryResponse>>
{
    [Required]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = null!;

    [Required]
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = null!;

    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}

public class ListMonthlyBudgetsQueryResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = null!;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = null!;

    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;
}

public class ListMonthlyBudgetsQueryHandler : IRequestHandler<ListMonthlyBudgetsQuery, TransactionResult<ListMonthlyBudgetsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public ListMonthlyBudgetsQueryHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public Task<TransactionResult<ListMonthlyBudgetsQueryResponse>> Handle(ListMonthlyBudgetsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}