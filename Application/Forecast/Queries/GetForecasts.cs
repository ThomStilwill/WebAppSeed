using System.Collections.Generic;
using MediatR;

namespace Application.Forecast.Queries
{
    public class GetForecasts : IRequest<IEnumerable<Domain.Weather.Forecast>>
    {
    }
}
