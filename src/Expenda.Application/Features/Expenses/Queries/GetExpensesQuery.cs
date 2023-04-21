using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.Expenses.Queries;

public class GetExpensesQuery : IRequest<TransactionResult<IEnumerable<ExpenseResponse>>> {}

public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, TransactionResult<IEnumerable<ExpenseResponse>>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _sessionManager;
    private readonly IExpenseRepository _repository;

    public GetExpensesQueryHandler(IMapper mapper, IApplicationSessionManager sessionManager, IExpenseRepository repository)
    {
        _mapper = mapper;
        _sessionManager = sessionManager;
        _repository = repository;
    }

    public async Task<TransactionResult<IEnumerable<ExpenseResponse>>> Handle(GetExpensesQuery request, CancellationToken token)
    {
        var entities = await _repository.GetAllExpensesForUser(_sessionManager.CurrentUser.Id, token);
        return new TransactionResult<IEnumerable<ExpenseResponse>>(_mapper.Map<IEnumerable<ExpenseResponse>>(entities));
    }
}