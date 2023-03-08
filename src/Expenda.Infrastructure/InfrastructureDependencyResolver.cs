using Microsoft.Extensions.DependencyInjection;
using Expenda.Domain.Repositories;
using Expenda.Infrastructure.Persistence;
using Expenda.Infrastructure.Persistence.Repositories;
using Expenda.Application.Architecture.Security.Managers;
using Expenda.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure;

public static class InfrastructureDependencyResolver
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ExpendaDatabase"), x =>
            {
                x.MigrationsAssembly("Expenda.Infrastructure");
            });
        });

        services
            .AddTransient<IPasswordManager, PasswordManager>()
            .AddTransient<ITokenManager, TokenManager>();

        services
            .AddScoped<IExpenseRepository, ExpenseRepository>()
            .AddScoped<IMonthlyBudgetRepository, MonthlyBudgetRepository>();

        return services;
    }
}