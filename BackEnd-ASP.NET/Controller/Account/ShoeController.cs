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
        private readonly IShoeRepository shoeRepository;
        public ShoeController(IShoeService shoeService, IShoeRepository shoeRepository)
        {
            this.shoeService = shoeService;
            this.shoeRepository = shoeRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllShoesAsync()
        {
            return await shoeService.GetAllShoesAsync();
        }

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoeById(Guid id, [FromForm] ShoePostDTO shoe)
        {
            return await shoeService.UpdateShoeAsync(id, shoe);
        }

        [HttpGet("cart")]
        public async Task<IActionResult> GetCartShoe([FromBody] List<Guid> shoeIds)
        {
            if (shoeIds == null || shoeIds.Count == 0)
            {
                return BadRequest("No shoe IDs provided.");
            }

            var shoes = await shoeRepository.GetShoesByIdsAsync(shoeIds);
            var shoesCartDTO = shoes.Select(shoe => new ShoeOrderDTO
            {
                ShoeId = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                MainImageUrl = shoe.ImageUrl,
            }).ToList();

            if (shoesCartDTO == null || shoesCartDTO.Count == 0)
            {
                return NotFound("No shoes found for the provided IDs.");
            }

            return Ok(shoesCartDTO);
        }

    }
}