using Application.Abstractions;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Weather;
using Foundation.Application.Abstractions;

namespace Application.Weather.Commands
{
    internal class CreateForecastCommandHandler : IRequestHandler<CreateForecastCommand>
    {
        private readonly IRepository<Forecast> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateForecastCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Forecast>();
        }

        public async Task Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(request.forecast);
            _unitOfWork.Commit();
        }
    }
}
