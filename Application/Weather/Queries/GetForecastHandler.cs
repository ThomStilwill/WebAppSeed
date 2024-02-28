using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Weather;
using Foundation.Application.Abstractions;
using Foundation.Mediator.Queries;

namespace Application.Weather.Queries
{
    public class GetForecastHandler : IQueryHandler<GetForecasts, IEnumerable<Forecast>>
    {
        private readonly IRepository<Forecast> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GetForecastHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Forecast>();
        }

        public async Task<IEnumerable<Forecast>> Handle(GetForecasts request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _repository.GetAll());
        }
    }
}
