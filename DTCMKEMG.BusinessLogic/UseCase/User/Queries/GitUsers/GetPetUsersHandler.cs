
using DTCMKEMG.BusinessLogic.DTOs;
using DTCMKEMG.DataAccess.interfaces;

using Mapster;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUsers;

public sealed class GetPetUsersHandler
    : IRequestHandler<GetPetUsersQuery, List<UserResponse>>
{
    private readonly IEfRepository<DTCMKEMG.Entities.User> _repository;

    public GetPetUsersHandler(IEfRepository<DTCMKEMG.Entities.User> repository)
    {
        _repository = repository;
    }

    public async Task<List<UserResponse>> Handle(
        GetPetUsersQuery query,
        CancellationToken cancellationToken)
    {
        var users = await _repository.ListAsync(cancellationToken);

        if (users == null || !users.Any())
        {
            return new List<UserResponse>();
        }

        return users.Adapt<List<UserResponse>>();
    }
}