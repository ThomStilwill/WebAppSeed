using MediatR;

namespace Foundation.Mediator.Commands
{
    public interface ICommand : IRequest { }
    public interface ICommand<out TResult> : IRequest<TResult> { }
}
