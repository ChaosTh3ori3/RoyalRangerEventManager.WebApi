using Microsoft.AspNetCore.Mvc;
using RangerEventManager.WebApi.Authorization;
using RangerEventManager.WebApi.Repositories.Camp;
using RangerEventManager.WebApi.Services.UserService;

namespace RangerEventManager.WebApi.Controllers.Camp;

[ApiController]
[Route("camps")]
public class CampController(ICampRepository campRepository, IUserService userService): ControllerBase
{
    [HttpGet]
    [Authorize(PermissionItems.CampRead)]
    public async Task<IActionResult> GetAllCampsForUser()
    {
        var username = userService.GetCurrentUserFromHttpContext(HttpContext);
        var camps = await campRepository.GetAllCampsByUserNameFull(username);
        
        return StatusCode(StatusCodes.Status200OK, camps);
    }

    [HttpGet("overview")]
    [Authorize(PermissionItems.CampRead)]
    public async Task<IActionResult> GetCampsOverviewForUser()
    {
        var username = userService.GetCurrentUserFromHttpContext(HttpContext);
        var camps = await campRepository.GetAllCampsByUserNameOverview(username);
        
        return StatusCode(StatusCodes.Status200OK, camps);
    }
}