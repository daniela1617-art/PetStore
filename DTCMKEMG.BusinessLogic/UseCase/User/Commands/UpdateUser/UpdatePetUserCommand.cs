using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Commands.UpdateUser
{
    public class UpdatePetUserCommand : IRequest<int>
    {
        public UpdateUserRequest Request { get; set; }

        public UpdatePetUserCommand(UpdateUserRequest updateUserRequest)
        {
            Request = updateUserRequest;
        }
    }
}