using MediatR;
using DTCMKEMG.BusinessLogic.DTOs;
using Mapster;
using DTCMKEMG.BusinessLogic.UseCase.PetBrand.Queries.GetPetBrands; 
using DTCMKEMG.DataAccess.interfaces; 

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Queries.GetPetBrands;

internal sealed class GetPetBrandsHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
  : IRequestHandler<GetBrandsQuery, List<PetBrandResponse>>
{
    public async Task<List<PetBrandResponse>> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await _repository.ListAsync(cancellationToken);

        if (brands == null || !brands.Any())
        {
            return new List<PetBrandResponse>();
        }

        return brands.Adapt<List<PetBrandResponse>>();
    }
}
