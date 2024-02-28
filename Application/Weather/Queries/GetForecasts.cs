using System.Collections.Generic;
using Domain.Weather;
using Foundation.Mediator.Queries;
using MediatR;

namespace Application.Weather.Queries
{
    public class GetForecasts : IQuery<IEnumerable<Forecast>>
    {
    }
}
