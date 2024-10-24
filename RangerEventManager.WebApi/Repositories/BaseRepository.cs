using RangerEventManager.Persistence;

namespace RangerEventManager.WebApi.Repositories;

public abstract class BaseRepository
{
    protected EventManagerContext Context { get; }
    
    public BaseRepository(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        
        Context = scope.ServiceProvider.GetRequiredService<EventManagerContext>();
    }
}