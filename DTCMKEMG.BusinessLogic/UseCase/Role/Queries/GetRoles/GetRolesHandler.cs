using DTCMKEMG.BusinessLogic.DTOs;

using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRoles;

internal sealed class GetRolesHandler(IEfRepository<DTCMKEMG.Entities.Role> _repository)
    : IRequestHandler<GetRolesQuery, List<RoleResponse>>
{
    public async Task<List<RoleResponse>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        var roles = await _repository.ListAsync(cancellationToken);

        if (roles == null || !roles.Any())
        {
            return new List<RoleResponse>();
        }

        return roles.Adapt<List<RoleResponse>>();
    }
}