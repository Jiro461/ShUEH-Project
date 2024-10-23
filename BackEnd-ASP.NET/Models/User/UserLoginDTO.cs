namespace BackEnd_ASP_NET.Models
{
    public sealed class UserLoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
        public bool rememberMe { get; set; }

    }
}
