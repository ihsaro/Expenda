using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using MediatR;

namespace Expenda.Application.Features.Expenses.Queries;

public class ListMonthlyTotalExpensesQuery : IRequest<TransactionResult<ListMonthlyTotalExpensesQueryResponse>>
{
    [Required]
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [Required]
    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    [Required]
    [JsonPropertyName("email_address")]
    public required string EmailAddress { get; set; }

    [Required]
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; set; }
}

public class ListMonthlyTotalExpensesQueryResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    [JsonPropertyName("email_address")]
    public required string EmailAddress { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }
}

public class ListMonthlyTotalExpensesQueryHandler : IRequestHandler<ListMonthlyTotalExpensesQuery, TransactionResult<ListMonthlyTotalExpensesQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public ListMonthlyTotalExpensesQueryHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public Task<TransactionResult<ListMonthlyTotalExpensesQueryResponse>> Handle(ListMonthlyTotalExpensesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}