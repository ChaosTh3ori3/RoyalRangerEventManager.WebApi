using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RangerEventManager.Persistence;
using RangerEventManager.Persistence.Entities.User;
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

    private readonly string iamUserEndpoint = "http://localhost:8080/admin/realms/RoyalRangerEventManager/users";
    private readonly string tokenEndpoint = "http://localhost:8080/realms/RoyalRangerEventManager/protocol/openid-connect/token";
    private readonly string ClientId = "RREM-API";
    private readonly string ClientSecret = "K2bEJ84APoS8qLmymPkE97rAk9nzy4Qd";

    [Fact]
    [Trait("Category", "Integration")]
    public async Task AddNewIAMUser()
    {
        // arrange
        connectionString ??= "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=RREM";
        
        var getTokenServiceOptions = Options.Create(new IAMSettings()
        {
            ClientId = ClientId,
            ClientSecret = ClientSecret,
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
        // Assert.Single(users);
        Assert.Equal("test@test.com", users.First().UserName);
    }

    private async Task addIAMUserToIAM(IAMService iamService, string token)
    {
        var user = new KeycloakUser()
        {   
            Email = "test@test.com",
            Username = "test@test.com",
            FirstName = "test",
            LastName = "test",
            Enabled = true
        };
        
        await iamService.AddUser(user, token);
    }
}