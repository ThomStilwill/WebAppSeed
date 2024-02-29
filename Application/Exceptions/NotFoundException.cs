using System;

namespace Application.Exceptions
{
    namespace Domain.Exceptions
    {
        public abstract class NotFoundException : ApplicationException
        {
            protected NotFoundException(string message) : base($"Not Found - {message}")
            {
            }
        }
    }
}
