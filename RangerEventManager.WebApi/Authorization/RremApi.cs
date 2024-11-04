using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RangerEventManager.WebApi.Authorization
{
    public class RremApi
    {
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }
}
