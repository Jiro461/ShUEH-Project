using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP_NET
{
    public interface IStatisticRepository
    {
    #region Orders
        Task<object?> GetOrdersByMonthAsync();
        Task<object?> GetOrdersByStatusAsync();
        Task<object?> GetRevenueFromOrdersByMonthAsync();
        Task<object?> GetRecentDeliveredOrdersAsync();
        #endregion

        #region Shoes
        Object? GetMostSoldShoesByMonth();
        Object? GetMostViewedShoesByMonth();
        Task<object?> GetSoldShoesQuantityByBrandInMonthAsync();
        #endregion

        #region Users
        Task<object?> GetUsersByMonthAsync();
        Task<object?> GetTopDealsByUserAsync();
        #endregion

        #region SiteView
        Task<object?> GetSiteViewByDeviceInMonthAsync();
        Task<object?> GetSiteViewByMonthAsync();
        #endregion
    }

}