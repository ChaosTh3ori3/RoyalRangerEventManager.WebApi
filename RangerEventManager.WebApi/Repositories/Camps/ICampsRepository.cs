using RangerEventManager.Persistence.Entities.Camp;

namespace RangerEventManager.WebApi.Repositories.Camps
{
    public interface ICampsRepository
    {
        Task<List<CampEntity>> GetAll();
        Task<CampEntity> GetByCampNumber(long campNumber);
        Task Create(CampEntity camp);
        Task UpdateMembers(long campNumber, IEnumerable<string> members);
    }
}
