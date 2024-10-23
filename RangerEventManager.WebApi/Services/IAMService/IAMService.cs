using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using RangerEventManager.Persistence.Entities.User;
using RangerEventManager.Persistence.Settings;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RangerEventManager.WebApi.Services.IAMService;

public class IAMService(IOptions<IAMSettings> settingsOptions) : IIAMService
{
    public async Task<string?> GetAccessToken()
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Post, settingsOptions.Value.TokenEndpoint);

        request.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", settingsOptions.Value.ClientId),
            new KeyValuePair<string, string>("client_secret", settingsOptions.Value.ClientSecret)
        });
        
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            var jsonDocument = JsonDocument.Parse(jsonResponse);
            var accessToken = jsonDocument.RootElement.GetProperty("access_token").GetString();
            
            return accessToken;
        }
        throw new Exception($"Failed to get access token. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
    }

    public async Task<List<IAMUserEntity>> GetAllUsers(string accessToken)
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Get, settingsOptions.Value.UsersEndpoint);
        
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<IAMUserEntity>>(jsonResponse);

            return users; 
        }
        
        throw new Exception($"Failed to get users. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
    }

    public async Task AddUser(object user, string accessToken)
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Post, settingsOptions.Value.UsersEndpoint);
        
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        var jsonContent = JsonSerializer.Serialize(user);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        request.Content = content;
        
        var response = await client.SendAsync(request);
        
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Failed to add User. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
    }
}

public class KeycloakUser
{
    [JsonPropertyName("credentials")]
    public IEnumerable<object> Credentials { get; set; }
    [JsonPropertyName("attributes")]
    public object Attributes { get; set; }
    [JsonPropertyName("emailVerified")]
    public bool EmailVerified { get; set; }
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }
}