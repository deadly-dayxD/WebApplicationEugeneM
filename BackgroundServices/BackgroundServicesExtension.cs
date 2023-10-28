using Microsoft.Extensions.DependencyInjection;

namespace BackgroundServices
{
    public static class BackgroundServicesExtension
    {
        public static void AddBackgroundService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<WorkerBackgroundService>();
        }
    }
}