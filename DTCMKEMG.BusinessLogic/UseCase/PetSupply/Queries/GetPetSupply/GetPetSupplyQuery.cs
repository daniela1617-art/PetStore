using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupply
{
    public record GetPetSupplyQuery(long PetSupplyId)
        : IRequest<PetSupplyResponse>;
}