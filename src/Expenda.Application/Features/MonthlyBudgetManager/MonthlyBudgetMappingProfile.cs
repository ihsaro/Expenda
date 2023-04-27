using AutoMapper;
using Expenda.Application.Features.MonthlyBudgetManager.Commands;
using Expenda.Domain.Entities;

namespace Expenda.Application.Features.MonthlyBudgetManager;

public class MonthlyBudgetMappingProfile : Profile
{
    public MonthlyBudgetMappingProfile()
    {
        CreateMap<SetMonthlyBudgetCommand, MonthlyBudget>();
    }
}