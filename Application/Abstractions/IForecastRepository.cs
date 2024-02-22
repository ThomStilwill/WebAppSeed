using Foundation.Application.Abstractions;
using Domain.Weather;

namespace Application.Abstractions
{
    public interface IForecastRepository : IRepository<Forecast>
    {
       
    }
}
