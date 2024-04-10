using Microsoft.AspNetCore.Mvc;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Authorization;
using RangerEventManager.WebApi.Repositories.Camps;
using RangerEventManager.WebApi.Service.UserService;

namespace RangerEventManager.WebApi.Controller
{
    [ApiController]
    [Route("camps")]
    public class CampsController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICampsRepository campsRepository;

        public CampsController(
            IUserService userService,
            ICampsRepository campsRepository)
        {
            this.userService = userService;
            this.campsRepository = campsRepository;
        }

        [HttpGet]
        [Authorize(PermissionItems.CampsRead)]
        public async Task<IActionResult> GetAllCamps()
        {
            var camps = await campsRepository.GetAll();

            var user = userService.GetCurrentUser();

            return StatusCode(StatusCodes.Status200OK, camps);
        }

        [HttpPut]
        public async Task<IActionResult> AddNewCamp()
        {
            var user = userService.GetCurrentUser();

            var camp = new CampEntity
            {
                Name = "Name1",
                LeaderUserNames = new List<string> { user },
                MemberUserNames = new List<string> { user }
            };

            await campsRepository.Create(camp);

            return StatusCode(StatusCodes.Status200OK, camp);
        }
    }
}
