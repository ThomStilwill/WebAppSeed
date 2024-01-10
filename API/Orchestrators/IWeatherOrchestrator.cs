using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Weather;

namespace API.Orchestrators;

public interface IWeatherOrchestrator
{
    Task<IEnumerable<Forecast>> GetWeather();
}