using Application.Weather.Commands;
using Domain.Weather;
using FluentValidation;

namespace Application.Weather.Validators
{

    public sealed class CreateForecastCommandValidator : AbstractValidator<CreateForecastCommand>
    {
        public CreateForecastCommandValidator()
        {
            RuleFor(command => command.forecast.Summary)
                .NotEmpty()
                .WithMessage("The summary can't be empty.");

            RuleFor(command => command.forecast.TemperatureC)
                .NotEmpty()
                .WithMessage("The temperature can't be empty.");

            RuleFor(command => command.forecast.Date)
                .NotNull()
                .WithMessage("The date can't be empty.");

            RuleFor(command => command.forecast.Summary)
                .Must(summary => summary != WeatherSummary.Cold)
                .WithMessage("The summary not available.");
        }
    }
}
