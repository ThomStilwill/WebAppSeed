namespace Foundation.Mediator.Queries
{
    internal abstract record QueryBase<TResult> : RequestBase<TResult>, IQuery<TResult>;
}
