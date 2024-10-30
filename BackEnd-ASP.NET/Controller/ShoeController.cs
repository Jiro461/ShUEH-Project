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
        private readonly string[] homeShoe = { "Nike Youth React Presto Extreme", "Nike Air Max 270", "Nike Downshifter 13" };
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

            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
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

            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalShoe()
        {
            var totalShoe = await context.Shoes.CountAsync();
            return Ok(totalShoe);
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetHomeShoe()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoes = await context.Shoes
                            .Where(shoe => homeShoe.Contains(shoe.Name))
                            .OrderByDescending(o => o.Gender)
                            .ToListAsync();

            var shoesDTO = shoes.Select(shoe => new
            {
                Name = shoe.Name,
                Gender = shoe.Gender,
                Brand = shoe.Brand,
                Discount = shoe.Discount,
                Description = shoe.Description,
                ImageUrl = shoe.ImageUrl,
                Price = shoe.Price,
                Id = shoe.Id
            });
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

            var shoesDTO = shoeService.ConvertListToListShoeGetAllDTO(shoes, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoesDTO);
        }

        [HttpGet("collaboration")]
        public async Task<IActionResult> GetCollaborationShoe()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var shoe = await context.Shoes
                .FirstOrDefaultAsync(s => s.Name == "Satan" && s.Brand == "Nike");

            if (shoe == null) return NotFound("No collaboration shoe found.");
            var shoeDTO = shoeService.ConvertShoeToShoeGetDTO(shoe, userId != null ? Guid.Parse(userId) : null);
            return Ok(shoeDTO);
        }
        #endregion
        #region ComplexAPI
        //Get all shoes
        [HttpGet("all/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllShoesAsync(int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0) return BadRequest("Invalid page or page size");
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var totalShoes = await context.Shoes.CountAsync();

            var shoes = userId == null
                ? await shoeService.GetAllShoesAsync(page: page, pageSize: pageSize)
                : await shoeService.GetAllShoesAsync(Guid.Parse(userId), page: page, pageSize: pageSize);

            var response = new
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalShoes / pageSize),
                Data = shoes
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await shoeService.GetShoeByIdFromUserAsync(id, userId != null ? Guid.Parse(userId) : null);
        }
        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetShoeByIdFromAdminAsync(Guid id)
        {
            var IsAdmin = HttpContext.User.IsInRole("Admin");
            if (!IsAdmin) return Unauthorized();
            return await shoeService.GetShoeByIdFromAdminAsync(id);
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