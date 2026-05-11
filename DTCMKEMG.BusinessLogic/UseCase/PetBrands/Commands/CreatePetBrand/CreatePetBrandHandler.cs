using DTCMKEMG.DataAccess.interfaces;
using Mapster;
using MediatR;



namespace DTCMKEMG.BusinessLogic.UseCase.PetBrands.Commands.CreatePetBrand
{
    internal sealed class CreateBrandHandler(IEfRepository<DTCMKEMG.Entities.PetBrand> _repository)
    : IRequestHandler<CreatePetBrandCommand, int>
    {
        public async Task<int> Handle(CreatePetBrandCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var newBrand = command.Request.Adapt<DTCMKEMG.Entities.PetBrand>();

                var createdBrand = await _repository.AddAsync(newBrand, cancellationToken);

                return createdBrand.Id;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
