using API.Orchestrators;
using Domain.Weather;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherOrchestrator weatherOrchestrator;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherOrchestrator weatherOrchestrator)
        {
            this.weatherOrchestrator = weatherOrchestrator;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Forecast> Get()
        {
            return weatherOrchestrator.GetWeather();
        }
    }
}
