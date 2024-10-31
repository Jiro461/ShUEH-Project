using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface IDiscountRepository
{
    Task<Discount?> GetDiscountByIdAsync(Guid id);
    Task<IEnumerable<Discount>> GetAllDiscountsAsync();
    Task<bool> AddDiscountAsync(Discount discount);
    Task<bool> DeleteDiscountAsync(Guid id);
    Task<bool> UpdateDiscountAsync(Discount discount);
}

