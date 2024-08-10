using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RangerEventManager.Persistence.Dtos.Camp;
using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Authorization;
using RangerEventManager.WebApi.Domain.Base;
using RangerEventManager.WebApi.Domain.Camps.Operation;
using RangerEventManager.WebApi.Repositories.Camps;
using RangerEventManager.WebApi.Services.UserService;
using System.ComponentModel.DataAnnotations;

namespace RangerEventManager.WebApi.Controller
{
    [ApiController]
    [Route("camps")]
    [Authorize]
    public class CampsController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IOperationHandler<CampEntity, CreateCampOperation> createCampOperationHandler;
        private readonly IOperationHandler<CampEntity, AssingEmplyeOperation> assingEmployeeOperationHandler;
        private readonly ICampsRepository campsRepository;

        public CampsController(
            IUserService userService,
            IOperationHandler<CampEntity, CreateCampOperation> createCampOperationHandler,
            IOperationHandler<CampEntity, AssingEmplyeOperation> assingEmployeeOperationHandler,
            ICampsRepository campsRepository)
        {
            this.userService = userService;
            this.createCampOperationHandler = createCampOperationHandler;
            this.assingEmployeeOperationHandler = assingEmployeeOperationHandler;
            this.campsRepository = campsRepository;
        }

        [HttpGet]
        [ProducesResponseType<List<ReadCampDto>>(StatusCodes.Status200OK)]
        [AuthorizeResource(PermissionItems.CampsRead)]
        public async Task<IActionResult> GetAllCamps()
        {
            var camps = await campsRepository.GetAll();

            var user = userService.GetCurrentUser();

            return StatusCode(StatusCodes.Status200OK, camps);
        }

        [HttpPut("plan-camp")]
        [ProducesResponseType<ReadCampDto>(StatusCodes.Status200OK)]
        [AuthorizeResource(PermissionItems.CampsWrite)]
        public async Task<IActionResult> AddNewCamp([FromBody][Required] CreateCampDto createCampDto)
        {
            var user = userService.GetCurrentUser();

            var operation = new CreateCampOperation()
            {
                CreateUser = user,
                Description = createCampDto.Description,
                EstimatedParticipantQuantity = createCampDto.EstimatedParticipantQuantity,
                LeaderUsers = createCampDto.LeaderUsers,
                MainStartDate = createCampDto.MainStartDate,
                MainEndDate = createCampDto.MainEndDate,
                MemberUsers = createCampDto.MemberUsers,
                Name = createCampDto.Name,
                PostCampStartDate = createCampDto.PostCampStartDate,
                PostCampEndDate = createCampDto.PostCampEndDate,
                PreCampStartDate = createCampDto.PreCampStartDate,
                PreCampEndDate = createCampDto.PreCampEndDate
            };

            var createdCamp = await createCampOperationHandler.HandlyAsync(operation);

            return StatusCode(StatusCodes.Status200OK, createdCamp);
        }

        [HttpPut("{campNumber}/assign-employee")]
        [ProducesResponseType<ReadCampDto>(StatusCodes.Status200OK)]
        [AuthorizeResource(PermissionItems.CampsWrite)]
        public async Task<IActionResult> AssingEmployee(
            [FromRoute][Required] long campNumber,
            [FromBody][Required] AssingEmployeeDto assingEmployeeDto)
        {
            var operation = new AssingEmplyeOperation()
            {
                CampNumber = campNumber,
                EmployeeUserName = assingEmployeeDto.EmployeeUserName
            };

            var camp = await assingEmployeeOperationHandler.HandlyAsync(operation);

            return StatusCode(StatusCodes.Status200OK, camp);
        }
    }
}
