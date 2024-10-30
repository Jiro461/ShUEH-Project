using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IPaymentService
    {
        Task<IActionResult> HandleSuccessfulPaymentAsync(Guid orderId);
        Task<IActionResult> HandleFailedPaymentAsync(Guid orderId);
    }
}
