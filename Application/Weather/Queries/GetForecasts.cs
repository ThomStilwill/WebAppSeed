using System.Collections.Generic;
using Domain.Weather;
using MediatR;

namespace Application.Weather.Queries
{
    public class GetForecasts : IRequest<IEnumerable<Forecast>>
    {
    }
}
