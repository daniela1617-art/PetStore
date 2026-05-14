using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.UpdateRole
{
    public record UpdateRoleCommand(UpdateRoleRequest Request) : IRequest<int>;
}