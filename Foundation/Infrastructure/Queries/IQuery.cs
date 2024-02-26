using MediatR;

namespace Foundation.Infrastructure.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
