using AutoMapper;
using Expenda.Application.Features.ExpenseManager.Commands;
using Expenda.Application.Features.ExpenseManager.Models.Response;
using Expenda.Domain.Entities;

namespace Expenda.Application.Features.ExpenseManager;

public class ExpensesMappingProfile : Profile
{
    public ExpensesMappingProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>();
        CreateMap<UpdateExpenseCommand, Expense>();
        CreateMap<Expense, ExpenseResponse>();
    }
}