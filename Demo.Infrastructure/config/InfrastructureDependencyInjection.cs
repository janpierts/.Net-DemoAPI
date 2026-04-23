using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Demo.Application.Common;

namespace Demo.Infrastructure.config;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(InfrastructureDependencyInjection).Assembly)
            .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}