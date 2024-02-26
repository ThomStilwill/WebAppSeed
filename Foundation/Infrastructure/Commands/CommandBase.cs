namespace Foundation.Infrastructure.Commands
{
    public abstract record CommandBase : RequestBase, ICommand;
    public abstract record CommandBase<TResult> : RequestBase<TResult>, ICommand<TResult>;
}
