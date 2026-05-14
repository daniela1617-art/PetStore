using Ardalis.Specification;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Specifications
{
    public class GetPetUsersSpec
        : Specification<DTCMKEMG.Entities.User>
    {
        public GetPetUsersSpec()
        {
            Query.Include(u => u.Role);
        }
    }
}