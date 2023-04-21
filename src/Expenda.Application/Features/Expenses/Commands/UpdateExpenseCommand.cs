using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using Expenda.Domain.Entities;
using MediatR;

namespace Expenda.Application.Features.Expenses.Commands;

public class UpdateExpenseCommand : CreateExpenseCommand
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
}

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, TransactionResult<ExpenseResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public UpdateExpenseCommandHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public Task<TransactionResult<ExpenseResponse>> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}