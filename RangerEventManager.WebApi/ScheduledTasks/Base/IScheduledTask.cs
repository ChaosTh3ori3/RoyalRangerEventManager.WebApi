namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public interface IScheduledTask
{
    Task ExecuteAsync();
}