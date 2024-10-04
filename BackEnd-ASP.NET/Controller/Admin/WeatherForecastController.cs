
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP_NET.Models;
//using BackEnd-ASP.NET.Models;

namespace BackEnd_ASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult Get()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
            {
                var weather = new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
                return weather;
            })
            .ToList();
            return Ok(forecast);
        }

    }
}