using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.Roles.Commands.CreateRole
{
    internal sealed class CreateRoleHandler
        : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.Role> _repository;

        public CreateRoleHandler(
            IEfRepository<DTCMKEMG.Entities.Role> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            CreateRoleCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var newRole =
                    command.Request.Adapt<DTCMKEMG.Entities.Role>();

                var createdRole =
                    await _repository.AddAsync(
                        newRole,
                        cancellationToken);

                return createdRole.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}