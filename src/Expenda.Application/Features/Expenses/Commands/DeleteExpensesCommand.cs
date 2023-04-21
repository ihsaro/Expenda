using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using MediatR;

namespace Expenda.Application.Features.Expenses.Commands;

public class DeleteExpensesCommand : IRequest<TransactionResult<bool>>
{
    public required IEnumerable<int> ids { get; set; }
}

public class DeleteExpensesCommandHandler : IRequestHandler<DeleteExpensesCommand, TransactionResult<bool>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public DeleteExpensesCommandHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public Task<TransactionResult<bool>> Handle(DeleteExpensesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}