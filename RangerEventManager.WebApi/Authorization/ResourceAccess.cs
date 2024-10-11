using System.Text.Json.Serialization;

namespace RangerEventManager.WebApi.Authorization
{
    public class ResourceAccess
    {
        [JsonPropertyName("RREM-API")]
        public RremApi RremApi { get; set; }
    }
}
