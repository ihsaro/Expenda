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
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom((src, dest, _, context) => context.Items["OwnerId"]));
        CreateMap<UpdateExpenseCommand, Expense>();
        CreateMap<Expense, ExpenseResponse>();
    }
}