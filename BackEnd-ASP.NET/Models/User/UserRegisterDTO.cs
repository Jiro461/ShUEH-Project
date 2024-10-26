namespace BackEnd_ASP_NET.Models
{
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public bool Gender { get; set; }

    }
    public sealed class UserAddDTO : UserRegisterDto
    {
        public string Role { get; set; } = "User";
    }
}
