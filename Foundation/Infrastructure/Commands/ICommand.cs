using MediatR;

namespace Foundation.Infrastructure.Commands
{
    public interface ICommand : IRequest { }
    public interface ICommand<out TResult> : IRequest<TResult> { }
}
