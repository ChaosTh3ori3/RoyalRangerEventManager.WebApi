using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Repositories.Camps;

namespace RangerEventManager.WebApi.Controller
{
    [ApiController]
    [Route("camps")]
    [Authorize]
    public class CampsController : ControllerBase
    {
        private readonly ICampsRepository campsRepository;

        public CampsController(ICampsRepository campsRepository)
        {
            this.campsRepository = campsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCamps()
        {
            var camps = await campsRepository.GetAll();

            return StatusCode(StatusCodes.Status200OK, camps);
        }

        [HttpPut]
        public async Task<IActionResult> AddNewCamp()
        {
            var camp = new CampEntity
            {
                Name = "Name1",
                Leaders = new List<Persistence.Entities.Base.PersonEntity> { },
                Members = new List<Persistence.Entities.Base.PersonEntity> { }
            };

            await campsRepository.Create(camp);

            return StatusCode(StatusCodes.Status200OK, camp);
        }
    }
}
