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

namespace BackEnd_ASP.NET.Controller.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetOrdersByUserIdAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            return await orderService.GetOrdersByUserIdAsync(Guid.Parse(userId));
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            return await orderService.DeleteOrderAsync(id);
        }
        [HttpGet("all/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllOrdersAsync(int page, int pageSize)
        {
            if (page < 0 || pageSize < 0)
            {
                return BadRequest("Invalid page or page size");
            }
            return await orderService.GetAllOrdersAsync(page, pageSize);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            return await orderService.GetAllOrdersAsync(-1, -1);
        }
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await orderService.GetOrdersByStatusAsync(status);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            return await orderService.GetOrderByIdAsync(id);
        }
        [HttpPut("update/{id}/{status}")]
        public async Task<IActionResult> UpdateOrderAsync(Guid id, OrderStatus status)
        {
            return await orderService.UpdateOrderAsync(id, status);
        }
    }



}
