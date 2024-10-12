using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;

namespace BackEnd_ASP.NET.Controller.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpGet("Ipaddress")]
        public IActionResult Index()
        {
            var IPAddress = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IPAddress");
            return Ok(new { Ipadd = IPAddress.Value });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            return await accountService.Register(userDto);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            return await accountService.Login(userDto, HttpContext);

        }
    }


}
