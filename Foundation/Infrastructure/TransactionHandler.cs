using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Foundation.Application.Abstractions;
using MediatR;

namespace Foundation.Infrastructure
{
    // public interface ICommand : IRequest { }
    // public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand { }
    // public interface IQuery<out TResult> : IRequest<TResult> { }
    // public interface IQueryHandler<in TQuery, TResult>
    //     : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> { }

    public interface ICommand : IRequest { }
    public interface ICommand<out TResult> : IRequest<TResult> { }

    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand { }

    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult> { }

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
}
