using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;
using MediatR;
using Mapster;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupply
{
    internal sealed class GetPetSupplyHandler
        : IRequestHandler<GetPetSupplyQuery, PetSupplyResponse>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.PetSupply> _repository;

        public GetPetSupplyHandler(
            IEfRepository<DTCMKEMG.Entities.PetSupply> repository)
        {
            _repository = repository;
        }

        public async Task<PetSupplyResponse> Handle(
            GetPetSupplyQuery query,
            CancellationToken cancellationToken)
        {
            var petSupply =
                await _repository.GetByIdAsync(
                    query.PetSupplyId,
                    cancellationToken);

            if (petSupply == null)
            {
                return new PetSupplyResponse();
            }

            return petSupply.Adapt<PetSupplyResponse>();
        }
    }
}