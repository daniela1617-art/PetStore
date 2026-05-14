using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Commands.CreatePetSupply
{
    public class CreatePetSupplyCommand : IRequest<int>
    {
        public CreatePetSupplyRequest Request { get; set; }

        public CreatePetSupplyCommand(CreatePetSupplyRequest createPetSupplyRequest)
        {
            Request = createPetSupplyRequest;
        }
    }
}