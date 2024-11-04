using System.Collections.Generic;
using System.Threading.Tasks;
using RangerEventManager.Persistence.Entities.Camp;

namespace RangerEventManager.WebApi.Repositories.Camp;

public interface ICampRepository
{
    public Task<List<CampEntity>> GetAllCampsFull();
    public Task<List<CampEntity>> GetAllCampsByUserNameFull(string username);
    public Task<List<CampEntity>> GetAllCampsByUserNameOverview(string username);
}