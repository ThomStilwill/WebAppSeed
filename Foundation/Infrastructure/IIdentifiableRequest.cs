using System;
using MediatR;

namespace Foundation.Infrastructure
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
