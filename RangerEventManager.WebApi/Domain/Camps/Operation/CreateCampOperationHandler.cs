using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Domain.Base;
using RangerEventManager.WebApi.Repositories.Camps;

namespace RangerEventManager.WebApi.Domain.Camps.Operation
{
    public class CreateCampOperationHandler : IOperationHandler<CampEntity, CreateCampOperation>
    {
        private readonly ILogger<CreateCampOperationHandler> logger;
        private readonly ICampsRepository campsRepository;

        public CreateCampOperationHandler(
            ILogger<CreateCampOperationHandler> logger,
            ICampsRepository campsRepository)
        {
            this.logger = logger;
            this.campsRepository = campsRepository;
        }

        public async Task<CampEntity> HandlyAsync(CreateCampOperation operation)
        {
            logger.LogInformation("Create a new Camp.");

            var currentDateTime = DateTime.Now;

            operation.LeaderUsers.ToList().Add(operation.CreateUser);

            var newCamp = new CampEntity()
            {
                Name = operation.Name,
                CreateDate = currentDateTime,
                LastChangeDate = currentDateTime,
                Description = operation.Description,
                MainStartDate = operation.MainStartDate,
                MainEndDate = operation.MainEndDate,
                PreCampStartDate = operation.PreCampStartDate,
                PreCampEndDate = operation.PreCampEndDate,
                PostCampStartDate = operation.PostCampStartDate,
                PostCampEndDate = operation.PostCampEndDate,
                LeaderUsers = operation.LeaderUsers,
                MemberUsers = operation.MemberUsers,
                Deadlines = new List<DeadlineEnity>(),
                Events = new List<EventEntity>(),
                Materials = new List<MaterialEntity>(),
                Participants = new List<ParticipantEntity>(),
                ToDos = new List<ToDoEntity>(),
                Arcived = false,
            };

            if (operation.EstimatedParticipantQuantity < 150)
            {
                newCamp.Categoty = Persistence.Enums.CampCategoriesEnum.small;
            } else if (operation.EstimatedParticipantQuantity > 150 && operation.EstimatedParticipantQuantity < 500)
            {
                newCamp.Categoty = Persistence.Enums.CampCategoriesEnum.medium;
            } else  if (operation.EstimatedParticipantQuantity > 500)
            {
                newCamp.Categoty = Persistence.Enums.CampCategoriesEnum.big;
            }

            await campsRepository.Create(newCamp);

            return newCamp;
        }
    }
}
