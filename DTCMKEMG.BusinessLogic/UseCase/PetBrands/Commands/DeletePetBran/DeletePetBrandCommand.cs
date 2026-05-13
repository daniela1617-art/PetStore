using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand
{
    public record DeletePetBrandCommand(int brandId) : IRequest<int>;
}