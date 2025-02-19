using Microsoft.Extensions.DependencyInjection;
using QueueManagement.Services;

namespace QueueManagement.Configurations;

public static class QueueServicesConfiguration
{
    public static IServiceCollection RegisterQueueServices(
        this IServiceCollection services)
    {
        services.AddSingleton<IQueueService, QueueService>();
        
        return services;
    }
}