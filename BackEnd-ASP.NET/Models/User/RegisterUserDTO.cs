namespace BackEnd_ASP_NET.Models
{
    public sealed class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public bool Gender { get; set; }

    }
}
