using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WalkieTalkie.Application;

public static class ApplicationDependencyResolver
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}