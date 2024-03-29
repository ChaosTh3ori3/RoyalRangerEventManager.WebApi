namespace RangerEventManager.WebApi.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CampsCollectionName { get; set; }
    }
}
