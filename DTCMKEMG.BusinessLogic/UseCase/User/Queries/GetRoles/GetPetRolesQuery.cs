using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetRoles
{
    public record GetPetRolesQuery
        : IRequest<List<RoleResponse>>;
}