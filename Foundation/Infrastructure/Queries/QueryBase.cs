namespace Foundation.Infrastructure.Queries
{
    internal abstract record QueryBase<TResult> : RequestBase<TResult>, IQuery<TResult>;
}
