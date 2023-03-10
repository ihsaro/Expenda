using Microsoft.Extensions.DependencyInjection;
using Expenda.Domain.Repositories;
using Expenda.Infrastructure.Persistence;
using Expenda.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Expenda.Domain.Entities;

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
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services
            .AddScoped<IExpenseRepository, ExpenseRepository>()
            .AddScoped<IMonthlyBudgetRepository, MonthlyBudgetRepository>();

        return services;
    }
}