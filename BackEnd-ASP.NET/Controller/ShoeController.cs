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

namespace BackEnd_ASP.NET.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoeController : ControllerBase
    {
        private readonly string[] brands = { "Nike", "Adidas", "Puma", "Reebok", "Under Armour" };

        private readonly IShoeService shoeService;
        private readonly ShUEHContext context;
        private readonly IShoeRepository shoeRepository;
        public ShoeController(IShoeService shoeService, ShUEHContext context, IShoeRepository shoeRepository)
        {
            this.shoeService = shoeService;
            this.context = context;
            this.shoeRepository = shoeRepository;
        }
        #region SimpleAPI
        //Get count brand
        [HttpGet("count-brand")]
        public async Task<IActionResult> GetCountBrandShoe()
        {
            var brands = await context.Shoes.GroupBy(s => s.Brand).Select(g => new { Brand = g.Key, Count = g.Count() }).ToListAsync();
            return Ok(brands);
        }
        //Get shoe by brand
        [HttpGet("brand")]
        public async Task<IActionResult> GetShoeByBrand(string brand)
        {
            if (!brands.Contains(brand)) return NotFound("Invalid brand");
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoes = await context.Shoes
                .Where(s => s.Brand == brand)
                .OrderByDescending(s => s.CreateDate)
                .ToListAsync();

            var shoesDTO = shoeService.ConvertToShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        [HttpGet("newest/{number}")]
        public async Task<IActionResult> GetNewestShoe(int number)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoes = await context.Shoes
                .OrderByDescending(s => s.CreateDate)
                    .Take(number)
                    .ToListAsync();

            var shoesDTO = shoeService.ConvertToShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        [HttpGet("page/{page}")]
        public async Task<IActionResult> GetPageShoe(int page, int pageSize)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (page <= 0 || pageSize <= 0) return BadRequest("Invalid page or page size");

            var shoes = await context.Shoes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (!shoes.Any()) return NotFound("No shoes found");

            var totalShoes = await context.Shoes.CountAsync();
            var response = new
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalShoes / pageSize),
                Data = shoeService.ConvertToShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null)
            };
            return Ok(response);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalShoe()
        {
            var totalShoe = await context.Shoes.CountAsync();
            return Ok(totalShoe);
        }

        [HttpGet("home/{number}")]
        public async Task<IActionResult> GetHomeShoe(int number)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoes = await context.Shoes
                .OrderByDescending(s => s.Discount)
                .Take(number)
                .ToListAsync();

            var shoesDTO = shoeService.ConvertToShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        [HttpGet("most-sold/{number}")]
        public async Task<IActionResult> GetMostSoldShoe(int number)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoes = await context.Shoes
                .OrderByDescending(s => s.Sold)
                .Take(number)
                .ToListAsync();

            var shoesDTO = shoeService.ConvertToShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        [HttpGet("collaboration")]
        public async Task<IActionResult> GetCollaborationShoe()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoe = await context.Shoes
                .FirstOrDefaultAsync(s => s.Name == "Satan" && s.Brand == "Nike");

            if (shoe == null) return NotFound("No collaboration shoe found.");
            var shoeDTO = shoeService.ConvertToShoeGetDTO(new List<Shoe> { shoe }, userId != null ? Guid.Parse(userId) : null).First();
            return Ok(shoeDTO);
        }
        #endregion
        #region ComplexAPI
        //Get all shoes
        [HttpGet("all/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllShoesAsync(int page, int pageSize)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return await shoeService.GetAllShoesAsync(page: page, pageSize: pageSize);
            return await shoeService.GetAllShoesAsync(Guid.Parse(userId), page: page, pageSize: pageSize);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await shoeService.GetShoeByIdAsync(id, userId != null ? Guid.Parse(userId) : null);
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