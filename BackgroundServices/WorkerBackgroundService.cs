using Microsoft.Extensions.Hosting;

namespace BackgroundServices
{
    public class WorkerBackgroundService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(WorkerBackgroundService) + "_" + nameof(StartAsync));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(WorkerBackgroundService) + "_" + nameof(StopAsync));
            return Task.CompletedTask;
        }
    }
}
