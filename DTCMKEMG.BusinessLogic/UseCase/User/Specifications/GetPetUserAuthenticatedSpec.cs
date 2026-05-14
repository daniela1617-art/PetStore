using Ardalis.Specification;

namespace DTCMKEMG.BusinessLogic.UseCase.User.Specifications
{
    public class GetPetUserAuthenticatedSpec
        : Specification<DTCMKEMG.Entities.User>
    {
        public GetPetUserAuthenticatedSpec(
            string userName,
            string password)
        {
            Query.Where(u =>
                u.Username == userName &&
                u.PasswordHash == password
            );

            Query.Include(u => u.Role);
        }
    }
}