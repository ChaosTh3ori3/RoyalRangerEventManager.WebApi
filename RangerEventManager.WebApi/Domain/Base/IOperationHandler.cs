namespace RangerEventManager.WebApi.Domain.Base
{
    public interface IOperationHandler<TEntity, TOperation>
    {
        Task<TEntity> HandlyAsync(TOperation operation);
    }
}
