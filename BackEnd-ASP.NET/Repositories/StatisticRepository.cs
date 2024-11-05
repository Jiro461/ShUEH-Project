using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class StatisticRepository : IStatisticRepository
{
    private readonly DbSet<Order> _dbOrders;
    private readonly DbSet<SiteView> _dbSiteViews;
    private readonly DbSet<User> _dbUsers;
    private readonly DbSet<Shoe> _dbShoes;
    private readonly DbSet<ProductView> _dbProductViews;
    public StatisticRepository(ShUEHContext context)
    {
        _dbOrders = context.Orders;
        _dbSiteViews = context.SiteViews;
        _dbUsers = context.Users;
        _dbShoes = context.Shoes;
        _dbProductViews = context.ProductViews;
    }
    public Object GetMostSoldShoesByMonth()
    {
        var orderData = _dbOrders
       .Where(o => o.OrderDate.Year == DateTime.Now.Year)
       .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Shoe)
            .SelectMany(o => o.OrderItems.Select(oi => new
            {
                Month = o.OrderDate.Month,
                ShoeId = oi.ShoeId,
                ShoeBrand = oi.Shoe!.Brand,
                ShoeImageUrl = oi.Shoe!.ImageUrl,
                ShoeName = oi.Shoe!.Name,
                Quantity = oi.Quantity
            }))
       .AsEnumerable(); // Chuyển sang client-side

        var totalSoldByShoe = orderData
            .GroupBy(x => new { x.Month, x.ShoeId })
            .Select(g => new
            {
                Month = g.Key.Month,
                ShoeId = g.Key.ShoeId,
                ShoeBrand = g.First().ShoeBrand,
                ShoeImageUrl = g.First().ShoeImageUrl,
                ShoeName = g.First().ShoeName,
                TotalSold = g.Sum(x => x.Quantity)
            })
            .ToList();

        var mostSoldShoesByMonth = totalSoldByShoe
            .GroupBy(x => x.Month)
            .Select(g => g.OrderByDescending(x => x.TotalSold).FirstOrDefault())
            .OrderBy(x => x!.Month)
            .ToList();

        return mostSoldShoesByMonth;
    }


    public Object? GetMostViewedShoesByMonth()
    {
        var viewData = _dbProductViews
            .Where(pv => pv.ViewedDate.Year == DateTime.Now.Year)
            .GroupBy(pv => new { Month = pv.ViewedDate.Month, pv.ProductId })
            .Select(g => new
            {
                Month = g.Key.Month,
                ProductId = g.Key.ProductId,
                ViewCount = g.Count()
            })
            .ToList()
            .AsEnumerable();

        var shoes = _dbShoes.Where(p => viewData.Select(v => v.ProductId).Contains(p.Id)).ToList();

        var mostViewedShoesByMonth = viewData
            .Join(shoes, v => v.ProductId, s => s.Id, (v, s) => new { v.Month, s.Brand, s.ImageUrl, s.Id, s.Name, v.ViewCount })
            .GroupBy(x => x.Month)
            .Select(g => g.OrderByDescending(x => x.ViewCount).FirstOrDefault())
            .OrderBy(x => x!.Month)
            .ToList();

        return mostViewedShoesByMonth;
    }

    public async Task<object?> GetOrdersByMonthAsync()
    {
        var ordersByMonth = await _dbOrders
            .Where(o => o.OrderDate.Year == DateTime.Now.Year)
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new { Month = g.Key, TotalOrders = g.Count() })
            .OrderBy(x => x!.Month)
            .ToListAsync();
        var totalOrders = await _dbOrders.CountAsync();
        return new { ordersByMonth, totalOrders };
    }

    public async Task<object?> GetOrdersByStatusAsync()
    {
        var ordersByStatus = await _dbOrders
            .GroupBy(o => o.Status)
            .Select(g => new { Status = g.Key, TotalOrders = g.Count() })
            .ToListAsync();
        return ordersByStatus;
    }

    public async Task<object?> GetRecentDeliveredOrdersAsync()
    {
        var recentDeliveredOrders = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered)
            .Include(o => o.User)
            .Select(o => new { o.Id, o.User!.ProfileName, o.User!.AvatarUrl, o.TotalPrice, o.OrderDate })
            .OrderByDescending(o => o.OrderDate)
            .Take(10)
            .ToListAsync();
        return recentDeliveredOrders;
    }

    public async Task<object?> GetRevenueFromOrdersByMonthAsync()
    {
        var revenueFromOrdersByMonth = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered && o.OrderDate.Year == DateTime.Now.Year)
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new { Month = g.Key, TotalRevenue = g.Sum(o => o.TotalPrice) })
            .OrderBy(x => x!.Month)
            .ToListAsync();

        var totalRevenue = await _dbOrders.Where(o => o.Status == OrderStatus.Delivered && o.OrderDate.Year == DateTime.Now.Year).SumAsync(o => o.TotalPrice);
        return new { revenueFromOrdersByMonth, totalRevenue };
    }

    public async Task<object?> GetSiteViewByDeviceInMonthAsync()
    {
        var siteViewByDeviceInMonth = await _dbSiteViews
            .Where(sv => sv.ViewedDate.Year == DateTime.Now.Year && sv.ViewedDate.Month == DateTime.Now.Month)
            .GroupBy(sv => new { Month = sv.ViewedDate.Month, sv.Device })
            .Select(g => new { Month = g.Key.Month, Device = g.Key.Device, ViewCount = g.Count() })
            .ToListAsync();
        return siteViewByDeviceInMonth;
    }

    public async Task<object?> GetSiteViewByMonthAsync()
    {
        var siteViewByMonth = await _dbSiteViews
            .Where(sv => sv.ViewedDate.Year == DateTime.Now.Year)
            .GroupBy(sv => new { Month = sv.ViewedDate.Month })
            .Select(g => new { Month = g.Key.Month, ViewCount = g.Count() })
            .OrderBy(x => x!.Month)
            .ToListAsync();
        return siteViewByMonth;
    }

    public async Task<object?> GetSoldShoesQuantityByBrandInMonthAsync()
    {
        var soldShoesQuantityByBrandInMonth = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered && o.OrderDate.Year == DateTime.Now.Year)
            .SelectMany(o => o.OrderItems
                .Select(oi => new { oi.Shoe!.Brand, oi.Quantity }))
            .GroupBy(x => x.Brand)
            .Select(g => new { Brand = g.Key, TotalSold = g.Sum(x => x.Quantity) })
            .ToListAsync();

        return soldShoesQuantityByBrandInMonth;
    }

    public async Task<object?> GetUsersByMonthAsync()
    {
        var usersByMonth = await _dbUsers
            .Where(u => u.CreateDate.Year == DateTime.Now.Year)
            .GroupBy(u => u.CreateDate.Month)
            .Select(g => new { Month = g.Key, TotalUsers = g.Count() })
            .OrderBy(x => x!.Month)
            .ToListAsync();

        var totalUsers = await _dbUsers.CountAsync();
        return new { usersByMonth, totalUsers };
    }

    public async Task<object?> GetTopDealsByUserAsync()
    {
        var topDealsByUser = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered)
            .Include(o => o.User)
            .GroupBy(o => o.User!.Id)
            .Select(g => new { UserId = g.Key, UserName = g.First().User!.ProfileName, Email = g.First().User!.Email, Avatar = g.First().User!.AvatarUrl, TotalRevenue = g.Sum(o => o.TotalPrice) })
            .OrderByDescending(x => x!.TotalRevenue)
            .Take(10)
            .ToListAsync();
        return topDealsByUser;
    }
}