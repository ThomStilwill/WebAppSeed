using Application;
using Domain.Weather;

namespace API.Orchestrators
{
    public class WeatherOrchestrator : IWeatherOrchestrator
    {
        private readonly IWeatherService weatherService;

        public WeatherOrchestrator(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public IEnumerable<Forecast> GetWeather()
        {
            return weatherService.GetWeather();
        }

      
    }
}
