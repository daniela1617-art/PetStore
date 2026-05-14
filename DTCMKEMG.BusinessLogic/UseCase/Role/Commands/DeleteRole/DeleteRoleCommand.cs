using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand
{
    public record DeleteRoleCommand(int brandId) : IRequest<int>
    {
        public object RoleId { get; internal set; }
    }
}