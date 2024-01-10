using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Forecast.Queries;
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
     
    }
}
