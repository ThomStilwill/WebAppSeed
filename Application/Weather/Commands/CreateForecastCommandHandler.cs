using System.Threading.Tasks;
using System.Threading;
using Domain.Weather;
using Foundation.Application.Abstractions;
using Foundation.Mediator.Commands;

namespace Application.Weather.Commands
{
    internal class CreateForecastCommandHandler : ICommandHandler<CreateForecastCommand,bool>
    {
        private readonly IRepository<Forecast> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateForecastCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Forecast>();
        }

        public async Task<bool> Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(request.forecast);
            return true;
        }
    }
}
