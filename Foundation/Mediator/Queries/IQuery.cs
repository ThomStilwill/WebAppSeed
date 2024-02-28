using MediatR;

namespace Foundation.Mediator.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
