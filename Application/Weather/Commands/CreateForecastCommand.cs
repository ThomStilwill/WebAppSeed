using Domain.Weather;
using MediatR;

namespace Application.Weather.Commands
{
    public class CreateForecastCommand : IRequest
    {
        public Forecast forecast;
    }
}
