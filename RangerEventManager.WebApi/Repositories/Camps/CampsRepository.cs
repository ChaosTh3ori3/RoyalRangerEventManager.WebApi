using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Settings;

namespace RangerEventManager.WebApi.Repositories.Camps
{
    public class CampsRepository : BaseRepository<CampEntity>, ICampsRepository
    {
        public CampsRepository(IOptions<MongoDbSettings> dbSettings) 
            : base(dbSettings, dbSettings.Value.CampsCollectionName)
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

        public async Task<CampEntity> GetByCampNumber(long campNumber)
        {
            return await Collection.AsQueryable().FirstAsync(camp => camp.Number == campNumber);
        }

        public async Task UpdateMembers(long campNumber, IEnumerable<string> members)
        {
            var filter = Builders<CampEntity>.Filter.Eq(camp => camp.Number, campNumber);

            var update = Builders<CampEntity>.Update.Set(camp => camp.MemberUsers, members);

            await Collection.UpdateOneAsync(filter, update);
        }
    }
}
