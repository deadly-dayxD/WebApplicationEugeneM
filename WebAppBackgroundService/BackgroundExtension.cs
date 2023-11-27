using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Runtime.CompilerServices;

namespace WebAppBackgroundService
{
    public static class BackgroundExtension
    {
        public static void AddBackgroundServices(this IServiceCollection service)
        {
            service.AddHostedService<MyHostedService>();
        }
    }
}