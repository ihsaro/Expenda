using AutoMapper;
using Expenda.Application.Features.Expenses.Commands;
using Expenda.Application.Features.Expenses.Models.Response;
using Expenda.Domain.Entities;

namespace Expenda.Application.Features.Expenses;

public class ExpensesMappingProfile : Profile
{
    public ExpensesMappingProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>();
        CreateMap<UpdateExpenseCommand, Expense>();
        CreateMap<Expense, ExpenseResponse>();
    }
}