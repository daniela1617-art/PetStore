using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;
using System.Collections.Generic;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRoles
{
    public record GetRolesQuery() : IRequest<List<RoleResponse>>;
}