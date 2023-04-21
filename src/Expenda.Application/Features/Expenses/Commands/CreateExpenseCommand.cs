using AutoMapper;

using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.Expenses.Models.Response;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;

using MediatR;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Expenda.Application.Features.Expenses.Commands;

public class CreateExpenseCommand : IRequest<TransactionResult<ExpenseResponse>>
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [MaxLength(1000)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [Required]
    [JsonPropertyName("price")]
    public double Price { get; set; }
    
    [Required]
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [Required]
    [JsonPropertyName("transaction_date")]
    public DateOnly TransactionDate { get; set; }
}

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, TransactionResult<ExpenseResponse>>
{
    private readonly IExpenseRepository _repository;
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _sessionManager;

    public CreateExpenseCommandHandler(IExpenseRepository repository, IMapper mapper, IApplicationSessionManager sessionManager)
    {
        _repository = repository;
        _mapper = mapper;
        _sessionManager = sessionManager;
    }

    public async Task<TransactionResult<ExpenseResponse>> Handle(CreateExpenseCommand command, CancellationToken token)
    {
        var entity = _mapper.Map<Expense>(command);
        entity.Owner = _sessionManager.CurrentUser;
        _repository.Create(entity);
        await _repository.Commit(token);
        return new TransactionResult<ExpenseResponse>(_mapper.Map<ExpenseResponse>(entity));
    }
}