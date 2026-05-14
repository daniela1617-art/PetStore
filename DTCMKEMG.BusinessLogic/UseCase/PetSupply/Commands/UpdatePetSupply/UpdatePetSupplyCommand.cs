using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.UpdatePetSupply
{
    public record UpdatePetSupplyCommand(
        UpdatePetSupplyRequest Request)
        : IRequest<int>;
}