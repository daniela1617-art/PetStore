namespace DTCMKEMG.BusinessLogic.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Username { get; set; }
        public string? RoleName { get; set; }
    }

    public class CreatePetUserRequest
    {
        public int RoleId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }

    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }

    public class RoleResponse
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class UserByIdResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}