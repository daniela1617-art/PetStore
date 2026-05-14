using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.CreatePetSupply
{
    internal sealed class CreatePetSupplyHandler
        : IRequestHandler<CreatePetSupplyCommand, int>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.PetSupply> _repository;

        public CreatePetSupplyHandler(
            IEfRepository<DTCMKEMG.Entities.PetSupply> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            CreatePetSupplyCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var newPetSupply =
                    command.Request.Adapt<DTCMKEMG.Entities.PetSupply>();

                var createdPetSupply =
                    await _repository.AddAsync(
                        newPetSupply,
                        cancellationToken);

                return (int)createdPetSupply.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}