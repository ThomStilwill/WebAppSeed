using System.Collections.Generic;
using Domain.Weather;
using Foundation.Infrastructure.Queries;
using MediatR;

namespace Application.Weather.Queries
{
    public class GetForecasts : IQuery<IEnumerable<Forecast>>
    {
    }
}
