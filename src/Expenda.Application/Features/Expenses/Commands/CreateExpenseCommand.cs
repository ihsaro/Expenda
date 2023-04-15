using AutoMapper;

using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;

using MediatR;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Expenda.Application.Features.Expenses.Commands;

public class CreateExpenseCommand : IRequest<TransactionResult<CreateExpenseCommandResponse>>
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    public required string Name { get; set; }
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    public DateOnly TransactionDate { get; set; }
}

public class CreateExpenseCommandResponse : CreateExpenseCommand
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, TransactionResult<CreateExpenseCommandResponse>>
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

    public async Task<TransactionResult<CreateExpenseCommandResponse>> Handle(CreateExpenseCommand command, CancellationToken token)
    {
        var entity = _mapper.Map<Expense>(command);
        _repository.Create(entity);
        await _repository.Commit(token);
        return new TransactionResult<CreateExpenseCommandResponse>(_mapper.Map<CreateExpenseCommandResponse>(entity));
    }
}

public class CreateExpenseCommandProfile : Profile
{
    public CreateExpenseCommandProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>();
        CreateMap<Expense, CreateExpenseCommandResponse>();
    }
}