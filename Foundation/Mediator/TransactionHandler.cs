using System.Threading;
using System.Threading.Tasks;
using Foundation.Application.Abstractions;
using Foundation.Mediator.Commands;
using MediatR;

namespace Foundation.Mediator
{
    public class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly IRequestHandler<TCommand> _decorated;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TCommand> decorated, IUnitOfWork unitOfWork)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            await _decorated.Handle(request, cancellationToken);
            _unitOfWork.Commit();
        }
    }

    public class UnitOfWorkCommandHandlerDecorator<TCommand,TResult> : ICommandHandler<TCommand,TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly IRequestHandler<TCommand, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
        }

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
        {

            var result = await _decorated.Handle(command, cancellationToken);
            _unitOfWork.Commit();

            return result;
        }
    }

}