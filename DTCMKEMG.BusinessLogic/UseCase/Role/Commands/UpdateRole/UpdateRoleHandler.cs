using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.UpdatePetBrand;
using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.UpdateRole
{
    internal sealed class UpdateRoleHandler
        : IRequestHandler<UpdateRoleCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.Role> _repository;

        public UpdateRoleHandler(
            IEfRepository<DTCMKEMG.Entities.Role> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            UpdateRoleCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var existingRole =
                    await _repository.GetByIdAsync(command.Request.Id);

                if (existingRole is null)
                    return 0;

                existingRole =
                    command.Request.Adapt(existingRole);

                await _repository.UpdateAsync(existingRole, cancellationToken);

                return existingRole.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}