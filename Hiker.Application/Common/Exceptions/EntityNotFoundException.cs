using System;

namespace Hiker.Application.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Message { get;  }

        public EntityNotFoundException(string message) : base(message)
        {
            Message = message;
        }
    }
}