using AutoMapper;
using Expenda.Application.Features.MonthlyBudgetManager.Commands;
using Expenda.Domain.Entities;

namespace Expenda.Application.Features.MonthlyBudgetManager;

public class MonthlyBudgetMappingProfile : Profile
{
    public MonthlyBudgetMappingProfile()
    {
        CreateMap<SetMonthlyBudgetCommand, MonthlyBudget>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom((src, dest, _, context) => context.Items["OwnerId"]));
    }
}