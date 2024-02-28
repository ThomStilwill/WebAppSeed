using System.Collections.Generic;
using System.Threading.Tasks;
using API.Orchestrators;
using Domain.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet(Name = "Forecast")]
        public async Task<IEnumerable<Forecast>> Get()
        {
            return await weatherOrchestrator.GetWeather();
        }

        [HttpPost(Name = "Forecast")]
        public async Task Post([FromBody] Forecast forecast)
        {
            await weatherOrchestrator.CreateForecast(forecast);
        }

        [HttpDelete(Name = "Forecast")]
        public async Task Delete(int id)
        {
            await weatherOrchestrator.DeleteForecast(id);
        }
    }
}
