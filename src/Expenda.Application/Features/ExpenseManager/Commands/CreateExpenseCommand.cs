using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.ExpenseManager.Models.Response;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.ExpenseManager.Commands;

public class CreateExpenseCommand : IRequest<TransactionResult<ExpenseResponse>>, IValidatableObject
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
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
    public DateTime TransactionDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        if (Price <= 0)
        {
            errors.Add(new ValidationResult("Price cannot be 0 or negative"));
        }

        if (Quantity <= 0)
        {
            errors.Add(new ValidationResult("Quantity cannot be 0 or negative"));
        }

        return errors;
    }
}

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, TransactionResult<ExpenseResponse>>
{
    private readonly IExpenseRepository _repository;
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _session;

    public CreateExpenseCommandHandler(IExpenseRepository repository, IMapper mapper, IApplicationSessionManager session)
    {
        _repository = repository;
        _mapper = mapper;
        _session = session;
    }

    public async Task<TransactionResult<ExpenseResponse>> Handle(CreateExpenseCommand command, CancellationToken token)
    {
        var entity = _mapper.Map<Expense>(command, opt => opt.Items["OwnerId"] = _session.CurrentUserId);
        
        _repository.Create(entity);
        await _repository.CommitAsync(token);

        return new TransactionResult<ExpenseResponse>(_mapper.Map<ExpenseResponse>(entity));
    }
}