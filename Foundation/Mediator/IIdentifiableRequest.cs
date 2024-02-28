using System;
using MediatR;

namespace Foundation.Mediator
{

    internal interface IIdentifiableRequest : IRequest
    {
        Guid RequestId { get; }
    }

    internal interface IIdentifiableRequest<TResult> : IRequest<TResult>
    {
        Guid RequestId { get; }
    }
}
