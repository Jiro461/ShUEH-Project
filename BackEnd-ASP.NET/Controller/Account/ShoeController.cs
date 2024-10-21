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
        private readonly ShUEHContext context;
        public ShoeController(IShoeService shoeService, IShoeRepository shoeRepository, ShUEHContext context)
        {
            this.shoeService = shoeService;
            this.shoeRepository = shoeRepository;
            this.context = context;
        }
        [HttpGet("home")]
        public async Task<IActionResult> GetHomeShoe()
        {
            var shoes = await context.Shoes.OrderByDescending(s => s.Discount).Take(4).ToListAsync();
            return Ok(shoes);
        }
        [HttpGet("most-sold")]
        public async Task<IActionResult> GetMostSoldShoe()
        {
            var shoes = await context.Shoes.OrderByDescending(s => s.Sold).Take(10).ToListAsync();
            return Ok(shoes);
        }

        [HttpGet("collaboration")]
        public async Task<IActionResult> GetCollaborationShoe()
        {
            var shoes = await context.Shoes.Where(s => s.Name == "Satan" && s.Brand == "Nike").FirstOrDefaultAsync();
            return Ok(shoes);
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

        [HttpPost("cart")]
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