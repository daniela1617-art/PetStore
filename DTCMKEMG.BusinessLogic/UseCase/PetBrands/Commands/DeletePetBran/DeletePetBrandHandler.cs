using DTCMKEMG.DataAccess.interfaces;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.DeletePetBrand
{
    internal sealed class DeletePetBrandHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
        : IRequestHandler<DeletePetBrandCommand, int>
    {
        public async Task<int> Handle(DeletePetBrandCommand command, CancellationToken cancellationToken)
        {
            var existingBrand = await _repository.GetByIdAsync(command.brandId);

            if (existingBrand is null) return 0;

            await _repository.DeleteAsync(existingBrand, cancellationToken);

            return existingBrand.Id;
        }
    }
}