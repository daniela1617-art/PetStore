using DTCMKEMG.BusinessLogic.DTOs;
using MediatR;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Commands.CreateUser
{
    public class CreatePetUserCommand : IRequest<int>
    {
        public CreatePetUserRequest Request { get; set; }

        public CreatePetUserCommand(CreatePetUserRequest createPetUserRequest)
        {
            Request = createPetUserRequest;
        }
    }
}