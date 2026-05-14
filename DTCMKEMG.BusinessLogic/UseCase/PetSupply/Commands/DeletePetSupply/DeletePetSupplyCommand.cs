using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.DeletePetSupply
{
    public record DeletePetSupplyCommand(long petSupplyId)
        : IRequest<int>;
}