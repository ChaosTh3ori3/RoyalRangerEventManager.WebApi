using RangerEventManager.Persistence.Entities.Camp;
using RangerEventManager.WebApi.Domain.Base;
using RangerEventManager.WebApi.Exceptions.Camp;
using RangerEventManager.WebApi.Repositories.Camps;

namespace RangerEventManager.WebApi.Domain.Camps.Operation
{
    public class AssingEmplyeOperationHandler : IOperationHandler<CampEntity, AssingEmplyeOperation>
    {
        private readonly ICampsRepository campsRepository;
        private readonly ILogger<AssemblyLoadEventHandler> logger;

        public AssingEmplyeOperationHandler(
            ICampsRepository campsRepository,
            ILogger<AssemblyLoadEventHandler> logger)
        {
            this.campsRepository = campsRepository;
            this.logger = logger;
        }

        public async Task<CampEntity> HandlyAsync(AssingEmplyeOperation operation)
        {
            logger.LogInformation("Add employee to Camp.'CampNumber={campNumber}, Employee={employee}'",
                operation.CampNumber,
                operation.EmployeeUserName);

            var camp = await campsRepository.GetByCampNumber(operation.CampNumber);

            if (!camp.MemberUsers.Any(member => member == operation.EmployeeUserName))
            {
                var memberList = camp.MemberUsers.ToList();
                memberList.Add(operation.EmployeeUserName);
                await campsRepository.UpdateMembers(operation.CampNumber, memberList);

                camp.MemberUsers = memberList;
            }
            else
            {
                throw new MemberAlreadyExistsException(operation.CampNumber, operation.EmployeeUserName);
            }

            return camp;
        }
    }
}
