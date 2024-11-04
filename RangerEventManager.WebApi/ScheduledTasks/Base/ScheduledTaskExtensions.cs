namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public static class ScheduledTaskExtensions
{
    public static IServiceCollection AddScheduledTask<T>(this IServiceCollection services, string cronExpression) where T : class, IScheduledTask
    {
        services.AddSingleton<IScheduledTask, T>();

        services.AddHostedService(sp =>
        {
            var task = sp.GetRequiredService<IScheduledTask>();
            return new SchedulerBackgroundService(task, cronExpression);
        });

        return services;
    }
}