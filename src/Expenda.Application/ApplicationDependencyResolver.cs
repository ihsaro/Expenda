using Expenda.Application.Services;
using Expenda.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WalkieTalkie.Application;

public static class ApplicationDependencyResolver
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services
            .AddTransient<IAuthenticationService, AuthenticationService>()
            .AddTransient<IExpenseService, ExpenseService>()
            .AddTransient<IMonthlyBudgetService, MonthlyBudgetService>();

        return services;
    }
}