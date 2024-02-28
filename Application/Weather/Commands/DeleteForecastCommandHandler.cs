using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Weather;
using Foundation.Application.Abstractions;

namespace Application.Weather.Commands
{
    internal class DeleteForecastCommandHandler : IRequestHandler<DeleteForecastCommand>
    {
        private readonly IRepository<Forecast> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteForecastCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Forecast>();
        }

        public async Task Handle(DeleteForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = _repository.GetById(request.id);

            _repository.Remove(forecast);
        }
    }
}
