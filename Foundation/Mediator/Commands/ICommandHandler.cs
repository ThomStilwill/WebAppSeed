using MediatR;

namespace Foundation.Mediator.Commands
{
    internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand { }

    internal interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult> { }
}
