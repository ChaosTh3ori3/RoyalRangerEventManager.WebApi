using Cronos;

namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public class Scheduler(IScheduledTask scheduledTask, string cronExpressionString)
{
    private readonly CronExpression cronExpression = CronExpression.Parse(cronExpressionString);
    private CancellationTokenSource cancellationTokenSource;

    public async Task StartSchedulerAsync()
    {
        cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = cancellationTokenSource.Token;

        while (!token.IsCancellationRequested)
        {
            var nextOccurrence = cronExpression.GetNextOccurrence(DateTime.UtcNow);
            if (nextOccurrence.HasValue)
            {
                var delay = nextOccurrence.Value - DateTime.UtcNow;

                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay, token);
                }

                if (!token.IsCancellationRequested)
                {
                    await scheduledTask.ExecuteAsync();
                }
            }
        }
    }

    public void StopScheduler()
    {
        cancellationTokenSource?.Cancel();
    }
}