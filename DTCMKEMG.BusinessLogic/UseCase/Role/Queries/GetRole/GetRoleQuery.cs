using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRole
{
    public record GetRoleQuery(int RoleId) : IRequest<RoleResponse>;
}