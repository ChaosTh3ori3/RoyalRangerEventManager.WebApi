using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Settings;

namespace RangerEventManager.WebApi.Repositories.Camps
{
    public class CampsRepository : BaseRepository<CampEntity>, ICampsRepository
    {
        public CampsRepository(IOptions<MongoDbSettings> dbSettings) : base(dbSettings, dbSettings.Value.CampsCollectionName)
        {
        }

        public async Task Create(CampEntity camp)
        {
            await Collection.InsertOneAsync(camp);
        }

        public async Task<List<CampEntity>> GetAll()
        {
            return await Collection.AsQueryable()
                .ToListAsync();
        }
    }
}
