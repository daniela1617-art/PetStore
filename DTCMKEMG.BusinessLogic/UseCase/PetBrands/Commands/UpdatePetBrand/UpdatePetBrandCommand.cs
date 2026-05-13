using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.UpdatePetBrand
{
    public record UpdatePetBrandCommand(UpdatePetBrandRequest Request) : IRequest<int>;
}