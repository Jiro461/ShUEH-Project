using BackEnd_ASP_NET.Models;

public interface IWishListRepository
{
    Task<IEnumerable<WishlistItem>> GetWishList(Guid userId);
    Task<bool> AddToWishList(Guid userId, Guid shoeId);
    Task<bool> RemoveFromWishList(Guid userId, Guid shoeId);
}