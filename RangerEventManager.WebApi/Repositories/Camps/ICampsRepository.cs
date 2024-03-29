using RangerEventManager.Persistence.Entities.Camp;

namespace RangerEventManager.WebApi.Repositories.Camps
{
    public interface ICampsRepository
    {
        Task<List<CampEntity>> GetAll();

        Task Create(CampEntity camp);
    }
}
