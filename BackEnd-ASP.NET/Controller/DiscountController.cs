using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BackEnd_ASP.NET.Services.VnPay;
using Microsoft.AspNetCore.Cors;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using System.Net;
namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            return await _discountService.GetAllDiscountsFromClientAsync();
        }
        [HttpGet("all-admin")]
        public async Task<IActionResult> GetAllDiscountsFromAdmin()
        {
            return await _discountService.GetAllDiscountsAsync();
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddDiscount(DiscountDTO discountDTO)
        {
            return await _discountService.AddDiscountAsync(discountDTO);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            return await _discountService.DeleteDiscountAsync(id);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDiscount(Guid id, DiscountDTO discountDTO)
        {
            return await _discountService.UpdateDiscountAsync(id, discountDTO);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(Guid id)
        {
            return await _discountService.GetDiscountByIdAsync(id);
        }
    }
}

