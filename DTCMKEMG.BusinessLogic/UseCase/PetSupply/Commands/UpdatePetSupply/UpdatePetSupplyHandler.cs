using DTCMKEMG.DataAccess.interfaces;
using MediatR;
using Mapster;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.UpdatePetSupply
{
    internal sealed class UpdatePetSupplyHandler
        : IRequestHandler<UpdatePetSupplyCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.PetSupply> _repository;

        public UpdatePetSupplyHandler(
            IEfRepository<DTCMKEMG.Entities.PetSupply> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            UpdatePetSupplyCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var existingPetSupply =
                    await _repository.GetByIdAsync(command.Request.Id);

                if (existingPetSupply is null)
                    return 0;

                existingPetSupply =
                    command.Request.Adapt(existingPetSupply);

                await _repository.UpdateAsync(
                    existingPetSupply,
                    cancellationToken);

                return (int)existingPetSupply.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}