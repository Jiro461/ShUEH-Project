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
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService){
            _notificationService = notificationService;
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUserNotifications(){
            return await _notificationService.GetUserNotifications(HttpContext);
        }
        [HttpGet("admin")]
        public async Task<IActionResult> GetAdminNotifications(){
            return await _notificationService.GetAdminNotifications(HttpContext);
        }
        [HttpGet("admin/user/{userId}")]
        public async Task<IActionResult> AdminGetUserNotifications(Guid userId){
            return await _notificationService.AdminGetUserNotifications(HttpContext, userId);
        }
  
    }
}