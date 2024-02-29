using MediatR;

namespace Foundation.Mediator.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
