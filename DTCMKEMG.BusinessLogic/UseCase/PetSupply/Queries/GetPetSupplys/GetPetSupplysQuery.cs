using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetSupply.Queries.GetPetSupplies
{
    public record GetPetSuppliesQuery()
        : IRequest<List<PetSupplyResponse>>;
}