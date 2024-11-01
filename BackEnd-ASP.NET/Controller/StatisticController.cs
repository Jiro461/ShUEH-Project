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
        public async Task<IActionResult> GetMostSoldShoesByMonthAsync()
        {
            var shoes = await _statisticRepository.GetMostSoldShoesByMonthAsync();
            return Ok(shoes);
        }

        [HttpGet("shoes/most-viewed-monthly")]
        public async Task<IActionResult> GetMostViewedShoesByMonthAsync()
        {
            var shoes = await _statisticRepository.GetMostViewedShoesByMonthAsync();
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
    }
}