using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.Forecast.Queries
{
    public class GetForecastHandler : IRequestHandler<GetForecasts, IEnumerable<Domain.Weather.Forecast>>
    {
        private readonly IForecastRepository _repository;

        public GetForecastHandler(IForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Weather.Forecast>> Handle(GetForecasts request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
