using Domain.Weather;
using Foundation.Mediator.Commands;

namespace Application.Weather.Commands
{
    public record DeleteForecastCommand(int id) : CommandBase { }
}
