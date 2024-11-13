using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class StatisticRepository : IStatisticRepository
{
    private readonly DbSet<Order> _dbOrders;
    private readonly ShUEHContext _context;
    private readonly DbSet<SiteView> _dbSiteViews;
    private readonly DbSet<User> _dbUsers;
    private readonly DbSet<Shoe> _dbShoes;
    private readonly DbSet<ProductView> _dbProductViews;
    // Constructor, khởi tạo các DbSet từ ShUEHContext để truy cập dữ liệu từ cơ sở dữ liệu
    public StatisticRepository(ShUEHContext context)
    {
        _dbOrders = context.Orders;
        _dbSiteViews = context.SiteViews;
        _dbUsers = context.Users;
        _dbShoes = context.Shoes;
        _dbProductViews = context.ProductViews;
        _context = context;
    }

    // Lấy danh sách giày bán chạy nhất theo tháng trong năm hiện tại
    public Object? GetMostSoldShoeByMonth()
    {
        // Lấy dữ liệu đơn hàng và trích xuất chi tiết giày, nhóm theo tháng và id giày
        var orderData = _dbOrders
           .Where(o => o.OrderDate.Year == DateTime.Now.Year) // Lọc theo năm hiện tại
           .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.Shoe)
           .SelectMany(o => o.OrderItems.Select(oi => new
           {
               Month = o.OrderDate.Month,   // Nhóm theo tháng
               ShoeId = oi.ShoeId,
               ShoeBrand = oi.Shoe!.Brand,
               ShoeImageUrl = oi.Shoe!.ImageUrl,
               ShoeName = oi.Shoe!.Name,
               Quantity = oi.Quantity
           }))
           .AsEnumerable(); // Thực hiện nhóm và tổng hợp dữ liệu sau khi lấy về từ cơ sở dữ liệu (client-side)

        // Tính tổng số lượng bán ra của từng đôi giày theo tháng
        var totalSoldByShoe = orderData
            .GroupBy(x => new { x.Month, x.ShoeId })
            .Select(g => new
            {
                Month = g.Key.Month,
                ShoeId = g.Key.ShoeId,
                ShoeBrand = g.First().ShoeBrand,
                ShoeImageUrl = g.First().ShoeImageUrl,
                ShoeName = g.First().ShoeName,
                TotalSold = g.Sum(x => x.Quantity) // Tính tổng số lượng bán
            })
            .ToList();

        // Lấy giày bán chạy nhất trong mỗi tháng, sắp xếp theo tháng
        var mostSoldShoesByMonth = totalSoldByShoe
            .GroupBy(x => x.Month)
            .Select(g => g.OrderByDescending(x => x.TotalSold).FirstOrDefault()) // Lấy giày bán chạy nhất mỗi tháng
            .OrderBy(x => x!.Month) // Sắp xếp theo tháng
            .ToList();

        return mostSoldShoesByMonth; // Trả về danh sách giày bán chạy nhất theo tháng
    }

    // Lấy danh sách giày được xem nhiều nhất theo tháng trong năm hiện tại
    public Object? GetMostViewedShoesByMonth()
    {
        var viewData = _dbProductViews
            .Where(pv => pv.ViewedDate.Year == DateTime.Now.Year) // Lọc theo năm hiện tại
            .GroupBy(pv => new { Month = pv.ViewedDate.Month, pv.ProductId }) // Nhóm theo tháng và id sản phẩm
            .Select(g => new
            {
                Month = g.Key.Month,
                ProductId = g.Key.ProductId,
                ViewCount = g.Count() // Đếm số lượt xem của sản phẩm
            })
            .ToList()
            .AsEnumerable();

        // Lấy danh sách giày từ các sản phẩm đã được xem
        var shoes = _dbShoes.Where(p => viewData.Select(v => v.ProductId).Contains(p.Id)).ToList();

        // Lấy giày được xem nhiều nhất trong mỗi tháng
        var mostViewedShoesByMonth = viewData
            .Join(shoes, v => v.ProductId, s => s.Id, (v, s) => new { v.Month, s.Brand, s.ImageUrl, s.Id, s.Name, v.ViewCount })
            .GroupBy(x => x.Month)
            .Select(g => g.OrderByDescending(x => x.ViewCount).FirstOrDefault()) // Lấy giày được xem nhiều nhất
            .OrderBy(x => x!.Month) // Sắp xếp theo tháng
            .ToList();

        return mostViewedShoesByMonth; // Trả về danh sách giày được xem nhiều nhất theo tháng
    }

    // Lấy số lượng đơn hàng theo tháng trong năm hiện tại
    public async Task<object?> GetOrdersByMonthAsync()
    {
        // Lấy số lượng đơn hàng theo tháng
        var ordersByMonth = await _dbOrders
            .Where(o => o.OrderDate.Year == DateTime.Now.Year) // Lọc theo năm hiện tại
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new { Month = g.Key, TotalOrders = g.Count() }) // Đếm số đơn hàng trong mỗi tháng
            .OrderBy(x => x!.Month)
            .ToListAsync();

        // Lấy tổng số đơn hàng trong năm
        var totalOrders = await _dbOrders.CountAsync();

        return new { ordersByMonth, totalOrders }; // Trả về số lượng đơn hàng theo tháng và tổng số đơn hàng
    }

    // Lấy số lượng đơn hàng theo trạng thái (Ví dụ: Đã giao, Đang xử lý)
    public async Task<object?> GetOrdersByStatusAsync()
    {
        var ordersByStatus = await _dbOrders
            .GroupBy(o => o.Status) // Nhóm theo trạng thái đơn hàng
            .Select(g => new { Status = g.Key, TotalOrders = g.Count() }) // Đếm số đơn hàng theo trạng thái
            .ToListAsync();

        return ordersByStatus; // Trả về số lượng đơn hàng theo trạng thái
    }

    // Lấy danh sách đơn hàng đã giao gần đây (10 đơn hàng gần nhất)
    public async Task<object?> GetRecentDeliveredOrdersAsync()
    {
        var recentDeliveredOrders = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered) // Lọc các đơn hàng đã giao
            .Include(o => o.User)
            .Select(o => new { o.Id, o.User!.ProfileName, o.User!.AvatarUrl, o.TotalPrice, o.OrderDate })
            .OrderByDescending(o => o.OrderDate) // Sắp xếp theo ngày giao
            .Take(10) // Lấy 10 đơn hàng gần nhất
            .ToListAsync();

        return recentDeliveredOrders; // Trả về danh sách các đơn hàng đã giao gần đây
    }

    // Lấy doanh thu từ các đơn hàng đã giao theo tháng trong năm hiện tại
    public async Task<object?> GetRevenueFromOrdersByMonthAsync()
    {
        var revenueFromOrdersByMonth = await _dbOrders
            .Where(o => o.Status == OrderStatus.Delivered && o.OrderDate.Year == DateTime.Now.Year) // Lọc các đơn hàng đã giao trong năm hiện tại
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new { Month = g.Key, TotalRevenue = g.Sum(o => o.TotalPrice) }) // Tính tổng doanh thu theo tháng
            .OrderBy(x => x!.Month)
            .ToListAsync();

        // Tính tổng doanh thu của tất cả các đơn hàng đã giao trong năm hiện tại
        var totalRevenue = await _dbOrders.Where(o => o.Status == OrderStatus.Delivered && o.OrderDate.Year == DateTime.Now.Year).SumAsync(o => o.TotalPrice);

        return new { revenueFromOrdersByMonth, totalRevenue }; // Trả về doanh thu theo tháng và tổng doanh thu
    }

    // Lấy số lượng lượt xem trang web theo thiết bị trong tháng hiện tại
    public async Task<object?> GetSiteViewByDeviceInMonthAsync()
    {
        var siteViewByDeviceInMonth = await _dbSiteViews
            .Where(sv => sv.ViewedDate.Year == DateTime.Now.Year && sv.ViewedDate.Month == DateTime.Now.Month) // Lọc theo tháng hiện tại
            .GroupBy(sv => new { Month = sv.ViewedDate.Month, sv.Device }) // Nhóm theo thiết bị
            .Select(g => new { Month = g.Key.Month, Device = g.Key.Device, ViewCount = g.Count() }) // Đếm số lượt xem theo thiết bị
            .ToListAsync();

        return siteViewByDeviceInMonth; // Trả về số lượt xem trang web theo thiết bị
    }

    // Lấy số lượt xem trang web theo tháng trong năm hiện tại
    public async Task<object?> GetSiteViewByMonthAsync()
    {
        var siteViewByMonth = await _dbSiteViews
            .Where(sv => sv.ViewedDate.Year == DateTime.Now.Year) // Lọc theo năm hiện tại
            .GroupBy(sv => new { Month = sv.ViewedDate.Month })
            .Select(g => new { Month = g.Key.Month, ViewCount = g.Count() }) // Đếm số lượt xem theo tháng
            .OrderBy(x => x!.Month)
            .ToListAsync();

        return siteViewByMonth; // Trả về số lượt xem trang web theo tháng
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
    public Object? GetMostSoldShoes()
    {
        var mostSoldShoes = _dbShoes.OrderByDescending(s => s.Sold).Take(10)
        .Select(s => new
        {
            s.Brand,
            s.ImageUrl,
            s.Name,
            s.Price,
            Quantity = s.shoeDetails.Sum(sd => sd.Quantity)
        })
        .ToList();

        return mostSoldShoes;
    }
}