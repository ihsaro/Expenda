using Expenda.Application.Architecture.Security;
using Microsoft.Extensions.DependencyInjection;
using Expenda.Domain.Repositories;
using Expenda.Infrastructure.Persistence;
using Expenda.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Expenda.Domain.Entities;
using Expenda.Infrastructure.Security;
using Expenda.Application.Architecture.Localization;
using Expenda.Infrastructure.Localization;
using Microsoft.AspNetCore.Identity;

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

        services.AddLocalization();

        services
            .AddTransient<IAuthenticationLocalizationMessenger, AuthenticationLocalizationMessenger>()
            .AddTransient<IExpenseLocalizationMessenger, ExpenseLocalizationMessenger>()
            .AddTransient<IMonthlyBudgetLocalizationMessenger, MonthlyBudgetLocalizationMessenger>();

        services
            .AddIdentityCore<IdentityUser<int>>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services
            .AddTransient<IApplicationUserManager, ApplicationUserManager>()
            .AddTransient<IApplicationTokenManager, ApplicationTokenManager>();

        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IApplicationGuestUserRepository, ApplicationGuestUserRepository>()
            .AddScoped<IApplicationUserRepository, ApplicationUserRepository>()
            .AddScoped<IExpenseRepository, ExpenseRepository>()
            .AddScoped<IMonthlyBudgetRepository, MonthlyBudgetRepository>()
            .AddScoped<IUserDataRepository, UserDataRepository>();

        return services;
    }
}