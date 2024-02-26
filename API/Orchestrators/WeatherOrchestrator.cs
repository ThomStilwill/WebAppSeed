using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Weather.Commands;
using Application.Weather.Queries;
using Domain.Weather;
using MediatR;

namespace API.Orchestrators
{
    public class WeatherOrchestrator : IWeatherOrchestrator
    {
        private readonly IMediator _mediator;

        public WeatherOrchestrator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Forecast>> GetWeather()
        {
            var request = new GetForecasts();
            var results = await _mediator.Send(request);
            return results;
        }

        public async Task CreateForecast(Forecast forecast)
        {
            var request = new CreateForecastCommand(forecast);
            await _mediator.Send(request);
        }
    }
}
