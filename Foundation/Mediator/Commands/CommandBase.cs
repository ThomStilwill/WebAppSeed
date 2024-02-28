namespace Foundation.Mediator.Commands
{
    public abstract record CommandBase : RequestBase, ICommand;
    public abstract record CommandBase<TResult> : RequestBase<TResult>, ICommand<TResult>;
}
