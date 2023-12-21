using Domain.Weather;
using Infrastructure;

namespace Application
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherData weatherData;

        public WeatherService(IWeatherData weatherData)
        {
            this.weatherData = weatherData;
        }

        public IEnumerable<Forecast> GetWeather()
        {
            return weatherData.GetWeather();
        }
    }
}
