using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RangerEventManager.Persistence;
using RangerEventManager.Persistence.Settings;
using RangerEventManager.WebApi.Mapper.UserMapper;
using RangerEventManager.WebApi.Repositories;
using RangerEventManager.WebApi.ScheduledTasks;
using RangerEventManager.WebApi.Services.IAMService;
using RangerEventManager.WebApi.Services.UserService;

namespace RangerEventManager.WebApi.IntegrationTests.Scheduler;

public class AddNewIAMUserSchedulerTaskTests
{

    private string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    private string? keyCloakHost = Environment.GetEnvironmentVariable("KeyCloak_Host_DefaultConnection");
    private string? keyCloakClientSecret = Environment.GetEnvironmentVariable("KeyCloak_Client_Secret");

    private string iamUserEndpoint;
    private string tokenEndpoint;
    private readonly string ClientId = "RREM-API";

    public AddNewIAMUserSchedulerTaskTests()
    {
        keyCloakHost ??= "http://localhost:8080";
        keyCloakClientSecret ??= "K2bEJ84APoS8qLmymPkE97rAk9nzy4Qd";
        connectionString ??= "User ID=postgres;Password=password;Server=localhost;Port=5432;Database=RREM";
        
        iamUserEndpoint = keyCloakHost + "/admin/realms/RoyalRangerEventManager/users";
        tokenEndpoint = keyCloakHost + "/realms/RoyalRangerEventManager/protocol/openid-connect/token";
    }


    [Fact]
    [Trait("Category", "Integration")]
    public async Task AddNewIAMUser()
    {
        // arrange
        var getTokenServiceOptions = Options.Create(new IAMSettings()
        {
            ClientId = ClientId,
            ClientSecret = keyCloakClientSecret,
            TokenEndpoint = tokenEndpoint,
            UsersEndpoint = iamUserEndpoint
        });
        
        var iamService = new IAMService(getTokenServiceOptions);
        var accessToken = await iamService.GetAccessToken();
        await addIAMUserToIAM(iamService, accessToken);

        var optionsBuilder = new DbContextOptionsBuilder<EventManagerContext>();
        optionsBuilder.UseNpgsql(connectionString);

        var context = new EventManagerContext(optionsBuilder.Options);
        
        var serviceProvider = new ServiceCollection();
        serviceProvider.AddSingleton(context);
        
        var userRepository = new UserRepository(serviceProvider.BuildServiceProvider());
        
        var userService = new UserService(userRepository);
        var userMapper = new UserMapper();
        
        var scheduler = new AddNewIAMUserSchedulerTask(iamService, userService, userRepository, userMapper);
        
        // act
        await scheduler.ExecuteAsync();

        // assert
        var users = context.Users.ToList();
        Assert.NotEmpty(users);
    }

    private async Task addIAMUserToIAM(IAMService iamService, string token)
    {
        var randomNumber = Random.Shared.Next(0, 100);
        var user = new KeycloakUser()
        {   
            Email = "test" + randomNumber + "@test.com",
            Username = "test@test.com" + randomNumber,
            FirstName = "test",
            LastName = "test",
            Enabled = true
        };
        
        await iamService.AddUser(user, token);
    }
}