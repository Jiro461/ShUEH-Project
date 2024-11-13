using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : ControllerBase
    {
        // Inject IStatisticRepository để truy cập dữ liệu thống kê từ database hoặc các nguồn khác
        private readonly IStatisticRepository _statisticRepository;

        // Constructor để khởi tạo repository cho controller
        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        #region Orders Statistics

        // API lấy thống kê số lượng đơn hàng theo tháng
        [HttpGet("orders/monthly")]
        public async Task<IActionResult> GetOrdersByMonthAsync()
        {
            // Gọi method từ repository để lấy dữ liệu số lượng đơn hàng theo tháng
            var orders = await _statisticRepository.GetOrdersByMonthAsync();
            return Ok(orders); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy thống kê số lượng đơn hàng theo trạng thái
        [HttpGet("orders/status")]
        public async Task<IActionResult> GetOrdersByStatusAsync()
        {
            // Gọi method từ repository để lấy dữ liệu số lượng đơn hàng theo trạng thái
            var orders = await _statisticRepository.GetOrdersByStatusAsync();
            return Ok(orders); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy các đơn hàng đã giao gần đây
        [HttpGet("orders/recent-delivered")]
        public async Task<IActionResult> GetRecentDeliveredOrdersAsync()
        {
            // Gọi method từ repository để lấy dữ liệu các đơn hàng đã được giao gần đây
            var orders = await _statisticRepository.GetRecentDeliveredOrdersAsync();
            return Ok(orders); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        #endregion

        #region Revenue Statistics

        // API lấy doanh thu theo tháng từ các đơn hàng
        [HttpGet("revenue/monthly")]
        public async Task<IActionResult> GetRevenueFromOrdersByMonthAsync()
        {
            // Gọi method từ repository để lấy doanh thu theo tháng từ các đơn hàng
            var revenue = await _statisticRepository.GetRevenueFromOrdersByMonthAsync();
            return Ok(revenue); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        #endregion

        #region Site View Statistics

        // API lấy thống kê lượt xem trang theo thiết bị trong tháng
        [HttpGet("site-views/device-monthly")]
        public async Task<IActionResult> GetSiteViewByDeviceInMonthAsync()
        {
            // Gọi method từ repository để lấy lượt xem trang theo thiết bị trong tháng
            var siteView = await _statisticRepository.GetSiteViewByDeviceInMonthAsync();
            return Ok(siteView); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy thống kê lượt xem trang theo tháng
        [HttpGet("site-views/monthly")]
        public async Task<IActionResult> GetSiteViewByMonthAsync()
        {
            // Gọi method từ repository để lấy lượt xem trang theo tháng
            var siteView = await _statisticRepository.GetSiteViewByMonthAsync();
            return Ok(siteView); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        #endregion

        #region Shoe Statistics

        // API lấy giày bán chạy nhất theo tháng
        [HttpGet("shoes/most-sold-monthly")]
        public IActionResult GetMostSoldShoesByMonthAsync()
        {
            // Gọi method từ repository để lấy giày bán chạy nhất theo tháng
            var shoes = _statisticRepository.GetMostSoldShoeByMonth();
            return Ok(shoes); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy giày được xem nhiều nhất theo tháng
        [HttpGet("shoes/most-viewed-monthly")]
        public IActionResult GetMostViewedShoesByMonthAsync()
        {
            // Gọi method từ repository để lấy giày được xem nhiều nhất theo tháng
            var shoes = _statisticRepository.GetMostViewedShoesByMonth();
            return Ok(shoes); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy số lượng giày bán theo thương hiệu trong tháng
        [HttpGet("shoes/sold-quantity-by-brand-monthly")]
        public async Task<IActionResult> GetSoldShoesQuantityByBrandInMonthAsync()
        {
            // Gọi method từ repository để lấy số lượng giày bán theo thương hiệu trong tháng
            var shoes = await _statisticRepository.GetSoldShoesQuantityByBrandInMonthAsync();
            return Ok(shoes); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        #endregion

        #region User Statistics

        // API lấy thống kê người dùng theo tháng
        [HttpGet("users/monthly")]
        public async Task<IActionResult> GetUsersByMonthAsync()
        {
            // Gọi method từ repository để lấy số lượng người dùng mới theo tháng
            var users = await _statisticRepository.GetUsersByMonthAsync();
            return Ok(users); // Trả về dữ liệu với mã trạng thái 200 OK
        }

        // API lấy thông tin các người dùng có giao dịch cao nhất
        [HttpGet("users/top-deals")]
        public async Task<IActionResult> GetTopDealsByUserAsync()
        {
            // Gọi method từ repository để lấy thông tin các người dùng có giao dịch cao nhất
            var topDeals = await _statisticRepository.GetTopDealsByUserAsync();
            return Ok(topDeals); // Trả về dữ liệu với mã trạng thái 200 OK
        }
        //http://localhost:5118/api/statistic/shoes/most-sold
        [HttpGet("shoes/most-sold")]
        public IActionResult GetMostSoldShoes()
        {
            var shoes = _statisticRepository.GetMostSoldShoes();
            return Ok(shoes);
        }

        #endregion
    }
}
