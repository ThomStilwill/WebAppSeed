using Domain.Weather;

namespace API.Orchestrators;

public interface IWeatherOrchestrator
{
    IEnumerable<Forecast> GetWeather();
}