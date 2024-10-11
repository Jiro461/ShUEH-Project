using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            return await accountService.Register(userDto);
        
        }
    }


}
