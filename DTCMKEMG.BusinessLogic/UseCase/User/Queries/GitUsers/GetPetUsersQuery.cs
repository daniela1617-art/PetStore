using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUsers
{
    public class GetPetUsersQuery
        : IRequest<List<UserResponse>>
    {
    }
}
