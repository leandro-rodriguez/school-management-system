using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagementSystem.API;


public static class MyDependencyInjections
{
    public static void SetUpMyServicesDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {

        var abstracts = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => (x.Namespace == "SchoolManagementSystem.Domain.Services" || 
                x.Namespace == "SchoolManagementSystem.Application.Authenticate.Interfaces"))
            .Where(x => x.IsInterface)
            .Where(x => !x.ContainsGenericParameters)
            .ToList();
        foreach (var item in abstracts)
            BootType(services, item);
    }

    private static void BootType(IServiceCollection services, Type type)
    {
        if (services.Any(x => x.ServiceType == type))
            return;
        var impls = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsAssignableTo(type))
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .ToList();
        if (impls.Count > 1)
            throw new Exception($"{type.Name} has more than one implementation");
        if (impls.Count == 0)
            return;
        var impl = impls.First();
        services.AddScoped(type, impl);
        var parameterTypes = impl
            .GetConstructors()
            .SelectMany(t => t.GetParameters())
            .Select(p => p.ParameterType)
            .ToList();
        foreach (var parameterType in parameterTypes)
            BootType(services, parameterType);
    }
}
