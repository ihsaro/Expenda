using AutoMapper;
using Expenda.Application.Features.ExpenseManager.Commands;
using Expenda.Application.Features.ExpenseManager.Models.Response;
using Expenda.Domain.Entities;

namespace Expenda.Application.Features.ExpenseManager;

public class ExpensesMappingProfile : Profile
{
    public ExpensesMappingProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>()
            .ForMember(dest => dest.Owner, opt => opt.MapFrom((src, dest, _, context) => context.Items["Owner"]));
        CreateMap<UpdateExpenseCommand, Expense>();
        CreateMap<Expense, ExpenseResponse>();
    }
}