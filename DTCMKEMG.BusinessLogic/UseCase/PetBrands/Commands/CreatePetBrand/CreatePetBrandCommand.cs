using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.CreatePetBrand
{
    public class CreatePetBrandCommand : IRequest<int>
    {
        public CreatePetBrandRequest Request { get; set; }

        public CreatePetBrandCommand(CreatePetBrandRequest createBrandRequest)
        {
            Request = createBrandRequest;
        }
    }
}