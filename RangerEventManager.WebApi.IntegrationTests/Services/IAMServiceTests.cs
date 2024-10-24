using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.Options;
using RangerEventManager.Persistence.Settings;
using RangerEventManager.WebApi.Services.IAMService;

namespace RangerEventManager.WebApi.IntegrationTests.Services;

public class IAMServiceTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public async void GetAccessToken()
    {
        //arrange
        var options = Options.Create(new IAMSettings()
        {
            ClientId = "RREM-API",
            ClientSecret = "hOyMXQuM5qQJ2ugT1xWd7zz88rqbyb8H",
            TokenEndpoint = "http://localhost:8081/realms/RoyalRangerEventManager/protocol/openid-connect/token"
        });
        
        var service = new IAMService(options);
        
        //act
        var accessToken = await service.GetAccessToken();
        
        //assert
        Assert.NotNull(accessToken);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void GetAllUsers()
    {
        //arrange
        var options = Options.Create(new IAMSettings()
        {
            ClientId = "RREM-API",
            ClientSecret = "hOyMXQuM5qQJ2ugT1xWd7zz88rqbyb8H",
            TokenEndpoint = "http://localhost:8081/realms/RoyalRangerEventManager/protocol/openid-connect/token",
            UsersEndpoint = "http://localhost:8081/admin/realms/RoyalRangerEventManager/users"
        });
        
        var service = new IAMService(options);

        //act
        var accessToken = await service.GetAccessToken();
        var users = await service.GetAllUsers(accessToken);

        //assert
        Assert.NotNull(users);
        Assert.NotEmpty(users);
        
        var user = users.FirstOrDefault();
        Assert.NotNull(user);
        Assert.NotNull(user.Email);
        Assert.NotNull(user.Username);
        Assert.NotNull(user.FirstName);
        Assert.NotNull(user.LastName);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void AddUser()
    {
        //arrange
        var options = Options.Create(new IAMSettings()
        {
            ClientId = "RREM-API",
            ClientSecret = "hOyMXQuM5qQJ2ugT1xWd7zz88rqbyb8H",
            TokenEndpoint = "http://localhost:8081/realms/RoyalRangerEventManager/protocol/openid-connect/token",
            UsersEndpoint = "http://localhost:8081/admin/realms/RoyalRangerEventManager/users"
        });
        
        var service = new IAMService(options);

        var user = new KeycloakUser()
        {
            Credentials = new List<object>(),
            Attributes = new object(),
            EmailVerified = false,
            Email = "rgdrvdrv@test.com",
            Username = "rddrvdrv@test.com",
            FirstName = "test",
            LastName = "test",
            Enabled = true
        };
        var minimalUser = new
        {
            username = "newuser",
            enabled = true
        };

        //act
        var accessToken = await service.GetAccessToken();
        await service.AddUser(user, accessToken);

        //assert
        Assert.NotNull(accessToken);
    }
}