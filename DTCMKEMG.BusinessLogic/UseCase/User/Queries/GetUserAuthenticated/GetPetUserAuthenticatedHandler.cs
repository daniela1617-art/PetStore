using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.BusinessLogic.UseCase.User.Specifications;
using DTCMKEMG.DataAccess.interfaces;

using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUserAuthenticated
{
    internal sealed class GetPetUserAuthenticatedHandler(
        IEfRepository<DTCMKEMG.Entities.User> _repository)
        : IRequestHandler<GetPetUserAuthenticatedQuery, UserResponse>
    {
        public async Task<UserResponse> Handle(
            GetPetUserAuthenticatedQuery query,
            CancellationToken cancellationToken)
        {
            var user = await _repository
                .FirstOrDefaultAsync(
                    new GetPetUserAuthenticatedSpec(
                        query.UserName,
                        query.Password),
                    cancellationToken
                );

            if (user is null)
            {
                return new UserResponse();
            }

            return user.Adapt<UserResponse>();
        }
    }
}