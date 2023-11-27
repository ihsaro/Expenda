using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Features.ExpenseManager.Models.Response;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.ExpenseManager.Commands;

public class UpdateExpenseCommand : CreateExpenseCommand
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, TransactionResult<ExpenseResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationSessionManager _applicationSessionManager;
    private readonly IExpenseLocalizationMessenger _expenseLocalizationMessenger;
    private readonly IExpenseRepository _expenseRepository;

    public UpdateExpenseCommandHandler(IMapper mapper,
                                       IApplicationSessionManager applicationSessionManager,
                                       IExpenseLocalizationMessenger expenseLocalizationMessenger,
                                       IExpenseRepository expenseRepository)
    {
        _mapper = mapper;
        _applicationSessionManager = applicationSessionManager;
        _expenseLocalizationMessenger = expenseLocalizationMessenger;
        _expenseRepository = expenseRepository;
    }

    public async Task<TransactionResult<ExpenseResponse>> Handle(UpdateExpenseCommand command, CancellationToken token)
    {
        var entity = await _expenseRepository.GetByIdAsync(command.Id, token);

        if (entity is null || entity.OwnerId != _applicationSessionManager.CurrentUserId)
        {
            return new TransactionResult<ExpenseResponse>()
                .AddErrorMessage(new ErrorMessage(_expenseLocalizationMessenger.GetMessage("EXPENSE_DOES_NOT_EXIST")));
        }

        entity = _mapper.Map<Expense>(command);
        _expenseRepository.Update(entity);

        await _expenseRepository.CommitAsync(token);

        return new TransactionResult<ExpenseResponse>(_mapper.Map<ExpenseResponse>(entity));
    }
}