using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;


namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Queries.GetPetBrand
{
    public record GetPetBrandQuery(int PetBrandId) : IRequest<PetBrandResponse>;
}
