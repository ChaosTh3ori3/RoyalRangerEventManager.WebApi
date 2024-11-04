using Cronos;

namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public class SchedulerBackgroundService(IScheduledTask scheduledTask, string cronString) : BackgroundService
{
    private readonly CronExpression cronExpression = CronExpression.Parse(cronString);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var nextOccurrence = cronExpression.GetNextOccurrence(DateTime.UtcNow);

            if (nextOccurrence.HasValue)
            {
                var delay = nextOccurrence.Value - DateTime.UtcNow;

                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, stoppingToken);
                }

                if (!stoppingToken.IsCancellationRequested)
                {
                    await scheduledTask.ExecuteAsync();
                }
            }
        }
    }
}