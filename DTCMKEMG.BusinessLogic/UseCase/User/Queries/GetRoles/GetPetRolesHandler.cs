using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;
using DTCMKEMG.Entities;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetRoles
{
    internal sealed class GetRolesHandler(
        IEfRepository<Role> _repository)
        : IRequestHandler<GetPetRolesQuery, List<RoleResponse>>
    {
        public async Task<List<RoleResponse>> Handle(
            GetPetRolesQuery query,
            CancellationToken cancellationToken)
        {
            var roles = await _repository.ListAsync(
                cancellationToken);

            if (roles == null || !roles.Any())
            {
                return new List<RoleResponse>();
            }

            return roles.Adapt<List<RoleResponse>>();
        }
    }
}