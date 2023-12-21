using Domain.Weather;

namespace Application
{
    public interface IWeatherService
    {
        IEnumerable<Forecast> GetWeather();
    }
}