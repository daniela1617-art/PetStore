using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Queries.GetUser
{
    public record GetPetUserQuery(int UserId)
        : IRequest<UserByIdResponse>;
}