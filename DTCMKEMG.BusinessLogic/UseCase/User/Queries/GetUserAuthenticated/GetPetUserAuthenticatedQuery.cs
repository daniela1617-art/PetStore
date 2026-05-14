using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUserAuthenticated
{
    public record GetPetUserAuthenticatedQuery(
        string UserName,
        string Password)
        : IRequest<UserResponse>;
}