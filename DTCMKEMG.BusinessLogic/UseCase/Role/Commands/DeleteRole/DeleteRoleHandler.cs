using DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand;
using DTCMKEMG.DataAccess.interfaces;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.DeleteRole
{
    internal sealed class DeleteRoleHandler
        : IRequestHandler<DeleteRoleCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.Role> _repository;

        public DeleteRoleHandler(
            IEfRepository<DTCMKEMG.Entities.Role> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            DeleteRoleCommand command,
            CancellationToken cancellationToken)
        {
            var existingRole =
                await _repository.GetByIdAsync(command.RoleId);

            if (existingRole is null)
                return 0;

            await _repository.DeleteAsync(existingRole, cancellationToken);

            return existingRole.Id;
        }
    }
}