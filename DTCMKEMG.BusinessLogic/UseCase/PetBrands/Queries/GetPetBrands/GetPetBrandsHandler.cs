using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.BusinessLogic.UseCase.PetBrand.Queries.GetPetBrands;
using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Queries.GetPetBrands;

internal sealed class GetPetBrandsHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
    : IRequestHandler<GetPetBrandsQuery, List<PetBrandResponse>>
{
    public async Task<List<PetBrandResponse>> Handle(GetPetBrandsQuery query,CancellationToken cancellationToken)
    {
        var brands = await _repository.ListAsync(cancellationToken);

        if (brands == null || !brands.Any())
        {
            return new List<PetBrandResponse>();
        }

        return brands.Adapt<List<PetBrandResponse>>();
    }
}