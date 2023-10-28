/*using Microsoft.Extensions.Hosting;

namespace BackgroundServices
{
    public class WorkerV1BackgroundService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine(nameof(WorkerV1BackgroundService) + "_" + nameof(ExecuteAsync));
            return Task.CompletedTask;
        }
    }
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine(nameof(WorkerV1BackgroundService) + "_" + nameof(StartAsync));
        base.StartAsync(cancellationToken);
        return Task.CompletedTask;
    }
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine(nameof(WorkerV1BackgroundService) + "_" + nameof(StopAsync));
        return Task.CompletedTask;
    }
}*/
