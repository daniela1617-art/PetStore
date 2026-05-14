using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;

using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUser
{
    internal sealed class GetPetUserHandler(
        IEfRepository<DTCMKEMG.Entities.User> _repository)
        : IRequestHandler<GetPetUserQuery, UserByIdResponse>
    {
        public async Task<UserByIdResponse> Handle(
            GetPetUserQuery query,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(
                query.UserId,
                cancellationToken);

            if (user is null)
            {
                return new UserByIdResponse();
            }

            return user.Adapt<UserByIdResponse>();
        }
    }
}