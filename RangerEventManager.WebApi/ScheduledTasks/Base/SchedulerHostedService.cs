namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public class SchedulerHostedService(Scheduler scheduler) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await scheduler.StartSchedulerAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        scheduler.StopScheduler();
        return Task.CompletedTask;
    }
}