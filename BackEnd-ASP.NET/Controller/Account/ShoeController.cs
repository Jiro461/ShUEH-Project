using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using BackEnd_ASP.NET.Models.User;
using Microsoft.AspNetCore.Authorization;
using BackEnd_ASP.NET.Models;

namespace BackEnd_ASP.NET.Controller.Shoe
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeService shoeService;

        public ShoeController(IShoeService shoeService)
        {
            this.shoeService = shoeService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllShoesAsync()
        {
            return await shoeService.GetAllShoesAsync();
        }

        [HttpGet("shoe/{id}")]
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            return await shoeService.GetShoeByIdAsync(id);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ShoePostDTO shoe)
        {
            try
            {
                return await shoeService.AddShoeAsync(shoe);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateShoeById(Guid id, [FromForm] ShoePostDTO shoe)
        {
            return await shoeService.UpdateShoeAsync(id, shoe);
        }


    }
}