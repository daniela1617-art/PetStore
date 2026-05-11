using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;
using MediatR;
using Mapster;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Queries.GetPetBrand
{
    internal sealed class GetPetBrandHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
     : IRequestHandler<GetPetBrandQuery, PetBrandResponse>
    {
        public async Task<PetBrandResponse> Handle(GetPetBrandQuery query, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetByIdAsync(query.PetBrandId, cancellationToken);

            if (brands == null)
            {
                return new PetBrandResponse();
            }

            return brands.Adapt<PetBrandResponse>();
        }
    }
}
