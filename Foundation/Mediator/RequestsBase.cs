using System;
using MediatR;

namespace Foundation.Mediator
{

    public abstract record RequestBase : IRequest, IIdentifiableRequest
    {
        protected RequestBase()
        {
            RequestId = Guid.NewGuid();
        }

        protected RequestBase(Guid id)
        {
            RequestId = id;
        }

        public Guid RequestId { get; private set; }
    }
    public abstract record RequestBase<TResult> : IRequest<TResult>, IIdentifiableRequest<TResult>
    {
        protected RequestBase()
        {
            RequestId = Guid.NewGuid();
        }

        protected RequestBase(Guid id)
        {
            RequestId = id;
        }

  public Guid RequestId { get; private set; }
    }
}
