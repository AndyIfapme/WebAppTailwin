using Microsoft.AspNetCore.Mvc;
using Refit;
using WebAppTailwin.Host.Services;

namespace WebAppTailwin.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WeathersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] double lat, [FromQuery] double lon)
        {
            var weatherApi = RestService.For<IWeatherApi>("https://api.openweathermap.org");
            var getWeatherResult = await weatherApi.GetWeather(_configuration["ApiKey"]!, lat, lon);

            return Ok(new GetWeatherResult
            {
                Temperature = getWeatherResult.main.temp
            });
        }
    }
}
