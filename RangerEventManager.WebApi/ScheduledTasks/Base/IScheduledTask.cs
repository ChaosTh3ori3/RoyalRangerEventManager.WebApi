using System.Threading.Tasks;

namespace RangerEventManager.WebApi.ScheduledTasks.Base;

public interface IScheduledTask
{
    Task ExecuteAsync();
}