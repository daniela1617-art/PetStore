using DTCMKEMG.BusinessLogic.DTOs;

using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Queries.GetRole
{
    internal sealed class GetRoleHandler(IEfRepository<DTCMKEMG.Entities.Role> _repository)
        : IRequestHandler<GetRoleQuery, RoleResponse>
    {
        public async Task<RoleResponse> Handle(GetRoleQuery query, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(query.RoleId, cancellationToken);

            if (role == null)
            {
                return new RoleResponse();
            }

            return role.Adapt<RoleResponse>();
        }
    }
}