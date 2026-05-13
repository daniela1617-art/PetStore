using DTCMKEMG.DataAccess.interfaces;
using MediatR;
using Mapster;


namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.UpdatePetBrand
{
    internal sealed class UpdateBrandHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
        : IRequestHandler<UpdatePetBrandCommand, int>
    {
        public async Task<int> Handle(UpdatePetBrandCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingBrand = await _repository.GetByIdAsync(command.Request.Id);

                if (existingBrand is null) return 0;

                existingBrand = command.Request.Adapt(existingBrand);

                await _repository.UpdateAsync(existingBrand, cancellationToken);

                return existingBrand.Id;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}