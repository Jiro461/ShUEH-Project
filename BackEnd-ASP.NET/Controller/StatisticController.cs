using Microsoft.AspNetCore.Mvc;


namespace BackEnd_ASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("orders/monthly")]
        public async Task<IActionResult> GetOrdersByMonthAsync()
        {
            var orders = await _statisticRepository.GetOrdersByMonthAsync();
            return Ok(orders);
        }

        [HttpGet("orders/status")]
        public async Task<IActionResult> GetOrdersByStatusAsync()
        {
            var orders = await _statisticRepository.GetOrdersByStatusAsync();
            return Ok(orders);
        }

        [HttpGet("orders/recent-delivered")]
        public async Task<IActionResult> GetRecentDeliveredOrdersAsync()
        {
            var orders = await _statisticRepository.GetRecentDeliveredOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("revenue/monthly")]
        public async Task<IActionResult> GetRevenueFromOrdersByMonthAsync()
        {
            var revenue = await _statisticRepository.GetRevenueFromOrdersByMonthAsync();
            return Ok(revenue);
        }

        [HttpGet("site-views/device-monthly")]
        public async Task<IActionResult> GetSiteViewByDeviceInMonthAsync()
        {
            var siteView = await _statisticRepository.GetSiteViewByDeviceInMonthAsync();
            return Ok(siteView);
        }

        [HttpGet("site-views/monthly")]
        public async Task<IActionResult> GetSiteViewByMonthAsync()
        {
            var siteView = await _statisticRepository.GetSiteViewByMonthAsync();
            return Ok(siteView);
        }

        [HttpGet("shoes/most-sold-monthly")]
        public IActionResult GetMostSoldShoesByMonthAsync()
        {
            var shoes = _statisticRepository.GetMostSoldShoesByMonth();
            return Ok(shoes);
        }

        [HttpGet("shoes/most-viewed-monthly")]
        public IActionResult GetMostViewedShoesByMonthAsync()
        {
            var shoes = _statisticRepository.GetMostViewedShoesByMonth();
            return Ok(shoes);
        }

        [HttpGet("shoes/sold-quantity-by-brand-monthly")]
        public async Task<IActionResult> GetSoldShoesQuantityByBrandInMonthAsync()
        {
            var shoes = await _statisticRepository.GetSoldShoesQuantityByBrandInMonthAsync();
            return Ok(shoes);
        }

        [HttpGet("users/monthly")]
        public async Task<IActionResult> GetUsersByMonthAsync()
        {
            var users = await _statisticRepository.GetUsersByMonthAsync();
            return Ok(users);
        }

        [HttpGet("users/top-deals")]
        public async Task<IActionResult> GetTopDealsByUserAsync()
        {
            var topDeals = await _statisticRepository.GetTopDealsByUserAsync();
            return Ok(topDeals);
        }
    }
}