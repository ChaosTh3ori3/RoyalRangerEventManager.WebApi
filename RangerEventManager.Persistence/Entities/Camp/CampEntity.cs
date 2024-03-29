using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RangerEventManager.Persistence.Entities.Base;

namespace RangerEventManager.Persistence.Entities.Camp
{
    public class CampEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public long Number { get; set; }
        public string? Name { get; set; }
        public DateTime StatDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PersonEntity>? Members { get; set; }
        public List<PersonEntity>? Leaders { get; set; }
    }
}
