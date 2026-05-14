using DTCMKEMG.DataAccess.interfaces;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.DeletePetSupply
{
    internal sealed class DeletePetSupplyHandler
        : IRequestHandler<DeletePetSupplyCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.PetSupply> _repository;

        public DeletePetSupplyHandler(
            IEfRepository<DTCMKEMG.Entities.PetSupply> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            DeletePetSupplyCommand command,
            CancellationToken cancellationToken)
        {
            var existingPetSupply =
                await _repository.GetByIdAsync(command.petSupplyId);

            if (existingPetSupply is null)
                return 0;

            await _repository.DeleteAsync(
                existingPetSupply,
                cancellationToken);

            return (int)existingPetSupply.Id;
        }
    }
}