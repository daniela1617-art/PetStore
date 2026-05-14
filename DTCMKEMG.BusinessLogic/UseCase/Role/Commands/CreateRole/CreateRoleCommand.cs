using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<int>
    {
        public CreateRoleRequest Request { get; set; }

        public CreateRoleCommand(CreateRoleRequest createRoleRequest)
        {
            Request = createRoleRequest;
        }
    }
}