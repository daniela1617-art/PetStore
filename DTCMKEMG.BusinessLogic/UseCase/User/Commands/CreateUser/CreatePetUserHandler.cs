using DTCMKEMG.DataAccess.interfaces;

using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Commands.CreateUser
{
    internal sealed class CreatePetUserHandler(
        IEfRepository<DTCMKEMG.Entities.User> _repository)
        : IRequestHandler<CreatePetUserCommand, int>
    {
        public async Task<int> Handle(
            CreatePetUserCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var newUser = command.Request.Adapt<DTCMKEMG.Entities.User>();

                var createdUser = await _repository.AddAsync(
                    newUser,
                    cancellationToken);

                return createdUser.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}