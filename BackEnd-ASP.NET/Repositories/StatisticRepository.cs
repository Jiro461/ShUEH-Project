using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class StatisticRepository :IStatisticRepository
{
    private readonly DbSet<Order> _dbOrders;
    private readonly DbSet<SiteView> _dbSiteViews;
    private readonly DbSet<User> _dbUsers;
    //private readonly DbSet<Shoe> _dbShoes;
    private readonly DbSet<ProductView> _dbProductViews;
    public StatisticRepository(ShUEHContext context)
    {
        _dbOrders = context.Orders;
        _dbSiteViews = context.SiteViews;
        _dbUsers = context.Users;
        //_dbShoes = context.Shoes;
        _dbProductViews = context.ProductViews;
    }
    public async Task<object?> GetMostSoldShoesByMonthAsync()
    {
        var mostSoldShoes = await _dbOrders
            .Where(o => o.OrderDate.Year == DateTime.Now.Year)
            .SelectMany(o => o.OrderItems.Select(oi => new { o.OrderDate, oi.ShoeId, oi.Quantity }))
            .GroupBy(x => new { x.OrderDate.Month, x.ShoeId })
            .Select(g => new { 
                g.Key.Month,
                g.Key.ShoeId,
                TotalSold = g.Sum(x => x.Quantity)
            })
            .GroupBy(x => x.Month)
            .Select(g => g
                .OrderByDescending(x => x.TotalSold)
                .FirstOrDefault())
            .ToListAsync();
        return mostSoldShoes;
    }


    public async Task<object?> GetMostViewedShoesByMonthAsync()
    {
        var mostViewedShoes = await _dbProductViews
            .Where(pv => pv.ViewedDate.Year == DateTime.Now.Year)
            .GroupBy(pv => new { Month = pv.ViewedDate.Month, pv.ProductId })
            .Select(g => new 
            { 
                Month = g.Key.Month,
                ProductId = g.Key.ProductId,
                ViewCount = g.Count()
            })
            .GroupBy(x => x.Month)
            .Select(g => g
                .OrderByDescending(x => x.ViewCount)
                .FirstOrDefault())
            .ToListAsync();

        return mostViewedShoes;
    }

    public async Task<object?> GetOrdersByMonthAsync()
    {
        var ordersByMonth = await _dbOrders
            .Where(o => o.OrderDate.Year == DateTime.Now.Year)
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new { Month = g.Key, TotalOrders = g.Count() })
            .ToListAsync();
        return ordersByMonth;
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
            .ToListAsync();
        return revenueFromOrdersByMonth;
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
            .ToListAsync();
        return usersByMonth;
    }
}