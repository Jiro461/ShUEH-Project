namespace BackEnd_ASP_NET.Models
{
    public sealed class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool rememberMe { get; set; }

    }
}
