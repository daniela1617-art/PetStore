using DTCMKEMG.DataAccess.interfaces;

using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Commands.UpdateUser
{
    internal sealed class UpdatePetUserHandler(
        IEfRepository<DTCMKEMG.Entities.User> _repository)
        : IRequestHandler<UpdatePetUserCommand, int>
    {
        public async Task<int> Handle(
            UpdatePetUserCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _repository.GetByIdAsync(
                    command.Request.Id,
                    cancellationToken);

                if (existingUser is null)
                {
                    return 0;
                }

                existingUser = command.Request.Adapt(existingUser);

                await _repository.UpdateAsync(
                    existingUser,
                    cancellationToken);

                return existingUser.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}