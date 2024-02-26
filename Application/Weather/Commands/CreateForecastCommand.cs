using Domain.Weather;
using Foundation.Infrastructure.Commands;

namespace Application.Weather.Commands
{
    public record CreateForecastCommand(Forecast forecast) : CommandBase { }
}
