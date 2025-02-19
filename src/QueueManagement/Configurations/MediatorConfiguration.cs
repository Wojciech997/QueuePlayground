using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace QueueManagement.Configurations;

public static class MediatorConfiguration
{
    public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
    {
        return services
            .AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}