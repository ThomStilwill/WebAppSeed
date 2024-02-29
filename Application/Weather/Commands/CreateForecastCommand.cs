using Domain.Weather;
using Foundation.Mediator.Commands;

namespace Application.Weather.Commands
{
    public record CreateForecastCommand(Forecast forecast) : ICommand<bool> { }
}
