using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;


namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.CreatePetBrand
{
    public class CreatePetBrandCommand : IRequest<int>

    {
        public required CreatePetBrandRequest Request { get; set; }

    }
}


