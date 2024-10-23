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
        #region SimpleAPI
        [HttpGet("newest/{number}")]
        public async Task<IActionResult> GetNewestShoe(int number)
        {
            var shoes = await context.Shoes.OrderByDescending(s => s.CreateDate).Take(number).ToListAsync();
            return Ok(shoes);
        }
        [HttpGet("page/{page}")]
        public async Task<IActionResult> GetPageShoe(int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest("Invalid page or page size");
            }
            var shoes = await context.Shoes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            if (!shoes.Any())
            {
                return NotFound("No shoes found");
            }
            var totalShoes = await context.Shoes.CountAsync();
            //Tạo response dạng object để trả về cho client
            var response = new
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalShoes / pageSize),
                Data = shoes
            };
            return Ok(response);
        }
        //Get total shoe
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalShoe()
        {
            var totalShoe = await context.Shoes.CountAsync();
            return Ok(totalShoe);
        }
        [HttpGet("home/{number}")]
        public async Task<IActionResult> GetHomeShoe(int number)
        {
            var shoes = await context.Shoes.OrderByDescending(s => s.Discount).Take(number).ToListAsync();
            return Ok(shoes);
        }
        [HttpGet("most-sold/{number}")]
        public async Task<IActionResult> GetMostSoldShoe(int number)
        {
            var shoes = await context.Shoes.OrderByDescending(s => s.Sold).Take(number).ToListAsync();
            return Ok(shoes);
        }

        [HttpGet("collaboration")]
        public async Task<IActionResult> GetCollaborationShoe()
        {
            var shoes = await context.Shoes.Where(s => s.Name == "Satan" && s.Brand == "Nike").FirstOrDefaultAsync();
            return Ok(shoes);
        }
        #endregion
        #region ComplexAPI
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
        #endregion
    }
}