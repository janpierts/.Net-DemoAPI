using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Demo.Application.Common;

namespace Demo.Application.config;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(ApplicationDependencyInjection).Assembly)
            .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}