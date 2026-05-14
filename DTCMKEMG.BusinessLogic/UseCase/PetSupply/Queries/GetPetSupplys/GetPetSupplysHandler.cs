using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupplies
{
    internal sealed class GetPetSuppliesHandler
        : IRequestHandler<GetPetSuppliesQuery, List<PetSupplyResponse>>
    {
        private readonly IEfRepository<DTCMKEMG.Entities.PetSupply> _repository;

        public GetPetSuppliesHandler(
            IEfRepository<DTCMKEMG.Entities.PetSupply> repository)
        {
            _repository = repository;
        }

        public async Task<List<PetSupplyResponse>> Handle(
            GetPetSuppliesQuery query,
            CancellationToken cancellationToken)
        {
            var petSupplies =
                await _repository.ListAsync(cancellationToken);

            if (petSupplies == null || !petSupplies.Any())
            {
                return new List<PetSupplyResponse>();
            }

            return petSupplies.Adapt<List<PetSupplyResponse>>();
        }
    }
}