using Microsoft.Extensions.Options;
using RangerEventManager.Persistence.Settings;

namespace RangerEventManager.WebApi.UnitTests.Services.IAMService;

public class IAMServiceTests
{
    private readonly WebApi.Services.IAMService.IAMService iamService;
    
    public IAMServiceTests()
    {
        var settings = Moq.Mock.Of<IOptions<IAMSettings>>();

        iamService = new WebApi.Services.IAMService.IAMService(settings);
    }
}