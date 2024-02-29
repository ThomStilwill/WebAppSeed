using System.Collections.Generic;
using Domain.Weather;
using Foundation.Mediator.Queries;

namespace Application.Weather.Queries
{
    public class GetForecasts : IQuery<IEnumerable<Forecast>>
    {
    }
}
